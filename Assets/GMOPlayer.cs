using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GMOPlayer
{

    public static GameObject heldItem;
    public static int amount;
    public static Holding holdState;
    public static ObjectTypes objectType;

    public static void pickUpItem(GameObject heldItem_, int amount_, Holding holdState_,ObjectTypes objectType_ = ObjectTypes.TOOL){
        heldItem = heldItem_;
        amount = amount_;
        holdState = holdState_;
        objectType = objectType_;
    }

    public static Holding whatTypeHolding(){
        return holdState;
    }

    public static GameObject getObjectHolding(){
        return heldItem;
    }

    public static ObjectTypes getTypeObject(){
        return objectType;
    }

    public static void useHolding(){
        if(holdState == Holding.NOTHING || holdState == Holding.WATER){
            return;
        }
        amount--;
        if(amount <= 0){
            holdNothing();
        }
    }

    public static int useHolding(int needed){
        if(holdState == Holding.NOTHING || holdState == Holding.WATER){
            return 0;
        }
        if(amount-needed < 0){
            int maxCanGive = amount;
            holdNothing();
            return maxCanGive;
        }
        if(amount-needed == 0){
            holdNothing();
        }
        return needed;
    }

    public static void holdNothing(){
        holdState = Holding.NOTHING;
        heldItem = null;
        amount = 0;
    }
    public static String PlayerToString(){
        String content = "";
        content += "Holding: "+holdState.ToString()+" ,amount:"+amount;
        return content;
    }
}

public enum Holding{
    NOTHING=0,
    WATER=1,
    OBJECT=2
}
