using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour,HoldableObject
{
    public Seed parentSeed;
    
    [Header("Fruit information")]
    public string type;
    public bool gmo;
    
    [Header("Fruit stats")]
    [Range(0,100)]
    public int sweet;
    [Range(0,100)]
    public int sour;
    [Range(0,100)]
    public int bitter;
    [Range(0,100)]
    public int salty;
    [Range(0,100)]
    public int spicy;
    [Range(0,100)]
    public int umami;
    [Range(0,100)]
    public int size;
    [Header("Fruit traits")]
    public List<Trait> traits;

    [Header("Visuals")]
    public string baseGraphicSource;
    public List<string> patterns;

    BaseGraphicSource bgs;
    List<Pattern> ps;



    public ObjectTypes getType()
        {
            return ObjectTypes.FRUIT;
        }


    // Start is called before the first frame update
    void Start()
    {
        bgs = new BaseGraphicSource(baseGraphicSource);
        foreach(string pattern in patterns){
            ps.Add(new Pattern(pattern));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
