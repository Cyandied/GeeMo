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
    public GameObject plantedSeed;
    public GameObject plant;
    [SerializeField]
    GameObject highlight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setBaseState(BaseStates state){
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
            reactToPlayerInput();
        }
    }

    void OnMouseExit(){
            highlight.SetActive(false);
    }

    void reactToPlayerInput(){
        if(GMOPlayer.holdState == Holding.WATER){
            setBaseState(BaseStates.WATERED);
        }
        else if(GMOPlayer.holdState == Holding.OBJECT){
            if(GMOPlayer.getTypeObject() == ObjectTypes.SEED && !occupied){
                plantSeed(GMOPlayer.getObjectHolding());
                GMOPlayer.useHolding();
                occupied = true;
            }
        }
    }

    void plantSeed(GameObject seed){
        plantedSeed = seed.GetComponent<Seed>().plantInSpot(gameObject);
    }

}

public enum BaseStates{
    DEFAULT=0,
    WATERED=1,
    DISABLED=2
}
