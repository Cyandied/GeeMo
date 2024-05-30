using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{

    public Seed parentSeed;
    public Fruit baseFruit;

    [Header("Plant information")]
    public string type;
    [Header("Plant stats")]
    [Range(0,100)]
    public int variation;
    [Range(1,15)]
    public int production;
    [Range(1,30)]
    public int growthRate;
    [Header("Plant traits")]
    public List<Trait> traits;
    [Header("Plant trackers")]
    public int growthStage;
    public bool isWithFruit;
    public bool isFlowering;
    public bool isWatered;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
