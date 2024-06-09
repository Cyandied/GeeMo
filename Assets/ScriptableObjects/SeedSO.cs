using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SeedSO", order = 2)]
public class SeedSO : ScriptableObject
{
    public PlantSO basePlant;
    public FruitSO baseFruit;
    public Sprite baseGraphicSource;

    public SeedSO PlantInSpot(GameObject plantSpotDisplay){
        plantSpotDisplay.GetComponent<SpriteRenderer>().sprite = baseGraphicSource;
        return Instantiate(this);
    }

    public PlantSO Sprout(){
        return basePlant.InstantiatePlant(this,baseFruit);
    }
}
