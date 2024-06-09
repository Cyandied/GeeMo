using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Stack : MonoBehaviour
{
    public GameObject content;
    public GameObject displayAmount;
    public GameObject spriteDisplay;
    public ObjectTypes type;
    public int amount;

    public void givePlayer(){
        GameObject existing = GMOPlayer.getObjectHolding();
        if(existing != null){
            if(existing.Equals(content)){
                GMOPlayer.holdNothing();
                return;
            }
        }
        gameObject.transform.parent.GetComponent<StackDisplay>().TakeOutStack(gameObject);
        GMOPlayer.pickUpItem(content,amount,Holding.OBJECT,type);
    }

    void Start(){
        spriteDisplay.GetComponent<Image>().sprite = content.GetComponent<SpriteRenderer>().sprite;
        displayAmount.GetComponent<TextMeshProUGUI>().text = ""+amount;
    }

}

public enum ObjectTypes {
    SEED = 0,
    FRUIT = 1,
    TOOL = 2,
}
