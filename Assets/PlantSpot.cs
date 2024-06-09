using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlantSpot : MonoBehaviour
{

    Boolean active;
    Boolean occupied;
    public BaseStates state;
    public SeedSO plantedSeed;
    public PlantSO plant;
    [SerializeField]
    GameObject highlight;
    [SerializeField]
    GameObject display;

    void Start()
    {
        if(plantedSeed == null && plant == null){
            display.SetActive(false);
        }
    }

    public void OrderDisplay(int order){
        display.GetComponent<SpriteRenderer>().sortingOrder = order;
    }

    public void SetBaseState(BaseStates state){
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        this.state = state;
        if(state == BaseStates.DISABLED){
            active = false;
        }
        else {
            active = true;
        }
        switch(state){
            case BaseStates.DEFAULT:
                active = true;
                renderer.color = new Color(77f/255f,30f/255f,15f/255f);
                break;
            case BaseStates.WATERED:
                active = true;
                renderer.color = new Color(41f/255f,16f/255f,8f/255f);
                break;
            default:
                active = false;
                renderer.color = new Color(77f/255f,30f/255f,15f/255f,120f/255f);
                break;
        }
    }

    void OnMouseOver(){
        Vector2 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray,Vector2.zero);
        if(hit){
            if(hit.collider.name != gameObject.name){
                return;
            }
        }
        if(active){
            highlight.SetActive(true);
        }
        if(Input.GetMouseButton(0)){
            ReactToPlayerInput();
        }
    }

    void OnMouseExit(){
            highlight.SetActive(false);
    }

    void ReactToPlayerInput(){
        if(GMOPlayer.holdState == Holding.WATER){
            WaterPlantSpot();
        }
        else if(GMOPlayer.holdState == Holding.OBJECT){
            if(GMOPlayer.getTypeObject() == ObjectTypes.SEED && !occupied){
                PlantSeed(GMOPlayer.getObjectHolding());
                GMOPlayer.useHolding();
                occupied = true;
            }
        }
    }

    void PlantSeed(GameObject seed){
        plantedSeed = seed.GetComponent<Seed>().PlantInSpot(display);
        display.SetActive(true);
    }

    void WaterPlantSpot(){
        SetBaseState(BaseStates.WATERED);
        if(plant == null){
            plant = plantedSeed.Sprout();
            display.GetComponent<SpriteRenderer>().sprite = plant.CurrentSprite();
        }
    }

    public void NewDay(){
        Grow();
        if(state != BaseStates.DISABLED){
            SetBaseState(BaseStates.DEFAULT);
        }
    }

    public void Grow(){
        if(plantedSeed == null || state == BaseStates.DISABLED){
            return;
        }
        if(plant == null && state == BaseStates.DEFAULT){
            plantedSeed = null;
            display.SetActive(false);
            occupied = false;
            return;
        }
        if(state == BaseStates.DEFAULT || plant == null){
            return;
        }
        plant.Grow();
        display.GetComponent<SpriteRenderer>().sprite = plant.CurrentSprite();
    }

}

public enum BaseStates{
    DEFAULT=0,
    WATERED=1,
    DISABLED=2
}
