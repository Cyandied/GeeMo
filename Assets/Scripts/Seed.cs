using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Seed : MonoBehaviour,HoldableObject
{
    public Plant basePlant;
    public Fruit baseFruit;

    public ObjectTypes getType()
    {
        return ObjectTypes.SEED;
    }

    public GameObject plantInSpot(GameObject plantSpot){
        GameObject clonedSeed = Instantiate(gameObject);
        clonedSeed.transform.SetParent(plantSpot.transform);
        clonedSeed.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        return clonedSeed;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
