using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/FruitSO", order = 0)]
public class FruitSO : ScriptableObject
{
    SeedSO parentSeed;
    
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
    public Sprite baseGraphicSource;
    public List<Sprite> patterns;

    BaseGraphicSource bgs;
    List<Pattern> ps;

    public FruitSO InstantiateFruit(SeedSO seed){
        parentSeed = seed;
        return Instantiate(this);
    }

}
