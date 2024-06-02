using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Stack : MonoBehaviour
{
    public GameObject content;
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
        GMOPlayer.pickUpItem(content,amount,Holding.OBJECT,type);
    }

}

public enum ObjectTypes {
    SEED = 0,
    FRUIT = 1,
    TOOL = 2,
}
