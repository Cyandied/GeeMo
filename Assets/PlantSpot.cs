using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlantSpot : MonoBehaviour
{

    Boolean active;
    public BaseStates state;
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
        if(active){
            highlight.SetActive(true);
        }
    }

    void OnMouseExit(){
            highlight.SetActive(false);
        }

}

public enum BaseStates{
    DEFAULT=0,
    WATERED=1,
    DISABLED=2
}
