using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
     public static ParticleController Instance;
    public GameObject waterEffect;
    private Vector2 mousePos;

    private void Awake(){
        if (Instance != null){
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start(){
        waterEffect.SetActive(false);
    }

    public ParticleController getInstance(){
        return Instance;
    }

    public void toggleOnWatereffect(Boolean toggle){
        if(toggle){
            waterEffect.SetActive(true);
            return;
        }
        waterEffect.SetActive(false);
    }

    public void updateWaterEffectPos(){
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        waterEffect.transform.position = new Vector3(mousePos.x,mousePos.y,-4f);
    }

}
