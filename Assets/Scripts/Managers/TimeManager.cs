using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance;
    [Header("Date and Time settings")]
    [Range(1,20)]
    public int date;
    [Range(1,4)]
    public int season;
    [Range(0,99)]
    public int year;
    [Range(0,24)]
    public int hour;
    [Range(0,12)]
    public int minute;
    private DateTime DateTime;

    [Header("Tick settings")]
    public int MinutesPerTick = 10;
    public float TimePerTick = 1;
    private float currentTimePerTick = 0;

    public static UnityAction<DateTime> OnDateTimeChanged;

    private void Awake(){
        if (Instance != null){
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        DateTime = new DateTime(date, season,year,hour,minute*5);
    }

    void Start(){
        OnDateTimeChanged?.Invoke(DateTime);
    }

    private void Update(){
        currentTimePerTick += Time.deltaTime;

        if(currentTimePerTick >= TimePerTick){
            currentTimePerTick = 0;
            Tick();
        }
    }

    void Tick(){
        AdvanceTime();
    }

    void AdvanceTime(){
        DateTime.AdvanceMinutes(MinutesPerTick);
        OnDateTimeChanged?.Invoke(DateTime);
    }

}

[System.Serializable]
public struct DateTime {

    // Fields
    private Days day;
    private int date;
    private int year;
    private int hour;
    private int minute;
    private Seasons season;
    private int totalDaysPassed;
    private int totalWeeksPassed;

    // Getters
    public Days Day => day;
    public int Date => date;
    public int Year => year;
    public int Hour => hour;
    public int Minute => minute;
    public Seasons Season => season;
    public int TotalDaysPassed => totalDaysPassed;
    public int TotalWeeksPassed => totalWeeksPassed;

    // Constructors
    public DateTime(int date, int season, int year, int hour, int minute){
        this.day = (Days)(date%5);
        if(day == 0) day = (Days)5;
        this.date = date;
        this.season = (Seasons)season;
        this.year = year;

        this.hour = hour;
        this.minute = minute;

        totalDaysPassed = date + (int)this.season * (5*4) + this.year * (5*4*4);
        totalWeeksPassed = 1 + totalDaysPassed/7;
    }

    // Time advancement
    public void AdvanceMinutes(int advanceByMinutes){
        // Debug.Log("The time and date is: "+hour+":"+minute+"\t"+day.ToString()+" : "+date+"/"+season.ToString()+"/"+year);
        if(minute + advanceByMinutes >= 60){
            minute = (minute + advanceByMinutes)%60;
            AdvanceHour(1);
        }
        else {
            minute += advanceByMinutes;
        }
    }

    public void AdvanceHour(int advanceByHours){
        Debug.Log(GMOPlayer.PlayerToString());
        if(hour + advanceByHours >= 24){
            hour = (hour + advanceByHours)%24;
            AdvanceDay();
        }
        else {
            hour += advanceByHours;
        }
    }

    public void AdvanceDay(){
        if (day + 1 > (Days)5){
            day = (Days)1;
            totalWeeksPassed++;
        }
        else {
            day++;
        }
        
        date++;

        if(date % 20 == 0){
            AdvanceSeason();
            date = 1;
        }

        totalDaysPassed++;
    }

    public void AdvanceSeason(){
        if(season == Seasons.winter){
            season = Seasons.spring;
            AdvanceYear();
        }
        else season++;
    }

    public void AdvanceYear(){
        year++;
    }

    // Checks
    public bool isEvening(){
        return hour >= 18 && hour <= 23;
    }
    public bool isNight(){
        return hour >= 0 && hour < 6;
    }
    public bool isMorning(){
        return hour >= 6 && hour < 12;
    }
    public bool isNoon(){
        return hour >= 12 && hour < 18;
    }
    public bool isWeekend(){
        return day == Days.sunday || (day == Days.friterday && isEvening());
    }
    public bool isThisDay(Days _day){
        return day == _day;
    }

    // Key dates TBA


}

public enum Days{
    NULL = 0,
    monday = 1,
    tuesday = 2,
    thurnesday = 3,
    friterday = 4,
    sunday = 5
}

public enum Seasons {
    spring = 1,
    summer = 2,
    autumn = 3,
    winter = 4
}