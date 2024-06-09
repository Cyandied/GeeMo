using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class PlantBed : MonoBehaviour
{

    public int upgradeLevel;
    public List<GameObject> plantSpots;
    [SerializeField]
    GameObject plantSpontPrefab;
    [SerializeField]

    TimeManager tm;
    
    void Awake()
    {
        tm = GameObject.Find("TimeManager").GetComponent<TimeManager>().GetInstance();
        tm.NewDay.AddListener(NewDay);
        tm.NewSeason.AddListener(NewSeason);
        distributePlantSpots(); 
    }

    void NewDay(Days day){
        foreach(GameObject plantSpot in plantSpots){
            plantSpot.GetComponent<PlantSpot>().NewDay();
        }
    }

    void NewSeason(Seasons season){

    }

    void distributePlantSpots(){
        float bedWidth = GetComponent<SpriteRenderer>().bounds.size.x;
        float spotWidth = plantSpots[0].GetComponent<SpriteRenderer>().bounds.size.x;
        float spacing = (bedWidth - spotWidth*4)/5;
        int position = 0;
        float xBefore = plantSpots[0].GetComponent<RectTransform>().position.x;
        float yBefore = plantSpots[0].GetComponent<RectTransform>().position.y;
        for(int num = 0;num < plantSpots.Count;num++){
            GameObject plantSpot = plantSpots[num];
            plantSpot.GetComponent<PlantSpot>().SetBaseState(BaseStates.DEFAULT);
            plantSpot.GetComponent<PlantSpot>().OrderDisplay((int)(4-math.floor(num/4)));
            float x = position*spotWidth + (position+1)*spacing;
            float y = math.floor(num/4)*spotWidth+(math.floor(num/4)+1)*spacing;
            plantSpot.GetComponent<RectTransform>().position = new Vector2(xBefore+x,yBefore+y);
            position++;
            if(position > 3){
                position = 0;
            }
        }
    }

}
