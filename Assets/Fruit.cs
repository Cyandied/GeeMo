using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour,HoldableObject
{
    public FruitSO fruit;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = fruit.baseGraphicSource;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public ObjectTypes getType()
    {
            return ObjectTypes.FRUIT;
    }
}
