using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PlantSO", order = 1)]
public class PlantSO : ScriptableObject
{

    SeedSO parentSeed;
    FruitSO baseFruit;

    [Header("Plant information")]
    public string type;
    [Header("Plant stats")]
    [Range(0,100)]
    public int variation;
    [Range(1,15)]
    public int production;
    [Range(1,3)]
    public int growthRate;
    [Range(1,10)]
    public int maxGrowthStage;
    [Header("Plant traits")]
    public List<Trait> traits;
    public List<Seasons> canGrowDuring;
    [Header("Plant trackers")]
    public int growthStage;
    public int daysSincePlanted;
    public bool isWithFruit;
    public bool isFlowering;
    public bool isWatered;
    [Header("Plant sprites")]
    public List<Sprite> baseGraphicSources;

    public PlantSO InstantiatePlant(SeedSO seed, FruitSO fruit){
        parentSeed = seed;
        baseFruit = fruit;
        return Instantiate(this);
    }

    public void Grow(){
        daysSincePlanted++;
        if(daysSincePlanted/growthRate > growthStage){
            growthStage++;
        }
        if(growthStage == maxGrowthStage){
            growthStage--;
        }
    }

    public Sprite CurrentSprite(){
        if(growthStage < baseGraphicSources.Count){
            return baseGraphicSources[growthStage];
        }
        return baseGraphicSources[0];
    }
}
