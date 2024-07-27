using System.Collections.Generic;
using UnityEngine;

public class CurserItemManager : MonoBehaviour
{
    public List<Sprite> tools;
    public SpriteRenderer sprite;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void BeginActiveState(){
        transform.Rotate(0,0,40);
    }

    public void EndActiveState(){
        transform.Rotate(0,0,-40);
    }

    public void DisplayTool(int index){
        if(index > tools.Count){
            Debug.Log("Tool doesnt exsist");
            return;
        }
        gameObject.SetActive(true);
        sprite.sprite = tools[index];
    }

    public void HideTool(){
        gameObject.SetActive(false);
    }

}
