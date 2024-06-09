using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StackDisplay : MonoBehaviour
{
    public List<GameObject> content;
    public GameObject stackPrefab;
    public GameObject scrollBar;
    float gap = 10;
    float stackPhyscialSize = 55;
    float xOffset = -302.5f;
    float yOffset = 137.5f;
    int itemsPerRow = 10;
    void Start()
    {
        PlaceStacks();
    }

    void PlaceStacks(){
        float row = 1;
        float col = 1;
        foreach(GameObject stack in content){
            stack.GetComponent<RectTransform>().anchoredPosition = new Vector2(
                col*gap + (col-1)*(stackPhyscialSize)+xOffset,
                -row*gap-(row-1)*(stackPhyscialSize)+yOffset
                );
            if(col == itemsPerRow){
                col=1;
                row++;
            }
            else {
                col++;
            }
        }
        ScrollBarToggle();
    }

    public void ScrollBarToggle(){
        bool toggle = content.Count/itemsPerRow > 5;
        scrollBar.GetComponent<Scrollbar>().interactable = toggle;
    }

    public void PutStackIn(GameObject stack){
        
    }

    public void PutItemIn(GameObject item){

    }

    public void TakeOutStack(GameObject stack){
        content.Remove(stack);
        PlaceStacks();
    }

    public void TakeOutItem(GameObject item, GameObject stack){

    }
}
