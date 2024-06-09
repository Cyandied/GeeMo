using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public PlantSO plant;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = plant.CurrentSprite();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
