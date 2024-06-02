using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    private void Awake(){
        if (Instance != null){
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public static void activateWateringCan(){
        if(GMOPlayer.holdState == Holding.WATER){
            GMOPlayer.holdNothing();
            return;
        }
        GMOPlayer.pickUpItem(null,0,Holding.WATER);
    }

}
