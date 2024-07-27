using System;
using UnityEngine;
using UnityEngine.Events;

public class TimeManager : MonoBehaviour
{

    public UnityEvent<Time> TimeUpdate;
    public UnityEvent<Date> DateUpdate;
    [Range(0,60)]
    public int minute;

    [Range(0,23)]
    public int hour;

    [Range(1,5)]
    public int day;

    [Range(1,30)]
    public int date;

    [Range(1,4)]
    public int season;
    
    [Range(0,999)]
    public int year;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start(){
        TimeUpdate.Invoke(new Time(hour, minute));
        DateUpdate.Invoke(new Date(day,date,season,year));
    }

    public void AdvanceTime(){
        AdvanceMinute();
    }

    void AdvanceMinute(){
        minute += 5;
        if(minute >= 60){
            AdvanceHour();
            minute = 0;
        }
        TimeUpdate.Invoke(new Time(hour, minute));
    }

    void AdvanceHour(){
        hour++;
        if(hour > 23){
            AdvanceDate();
            hour = 0;
        }
    }
    void AdvanceDate(){
        date++;
        if(date > 29){
            AdvanceSeason();
            date = 1;
        }
        day++;
        if(day > 5){
            day = 1;
        }
        DateUpdate.Invoke(new Date(day,date,season,year));
    }

    void AdvanceSeason(){
        season++;
        if(season > 4){
            year++;
            season = 1;
        }
    }
    
}

public class Time {
    private int hour;
    private int minute;
    public Time(int _hour, int _minute){
        hour = _hour;
        minute = _minute;
    }
    override
    public String ToString(){
        String hourS = hour < 10 ? "0"+hour : ""+hour;
        String minuteS = minute < 10 ? "0"+minute : ""+minute;
        return hourS+":"+minuteS;
    }
}

public class Date {
    private Days day;
    private int date;
    private Seasons season;
    private int year;

    public Date(int _day, int _date, int _season, int _year){
        day = (Days) _day;
        date = _date;
        season = (Seasons) _season;
        year = _year;
    }
    override
    public String ToString(){
        String dateS = date < 10 ? "0"+date : ""+date;
        String seasonS = season.ToString().Substring(0,1) + season.ToString().Substring(1).ToLower();
        return day.ToString() + " : " + dateS + " of " + seasonS + " " + year;
    }
}

public enum Days {
    DAY1 = 1,
    DAY2 = 2,
    DAY3 = 3,
    DAY4 = 4,
    DAY5 = 5
}

public enum Seasons {
    SPRING = 1,
    SUMMER = 2,
    AUTUMN = 3,
    WINTER = 4
}