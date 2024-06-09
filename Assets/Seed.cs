using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Seed : MonoBehaviour,HoldableObject
{
    public SeedSO seed;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = seed.baseGraphicSource;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public SeedSO PlantInSpot(GameObject plantSpotDisplay){
        return seed.PlantInSpot(plantSpotDisplay);
    }

    public ObjectTypes getType()
    {
        return ObjectTypes.SEED;
    }
}
