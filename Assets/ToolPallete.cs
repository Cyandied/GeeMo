using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolPallete : MonoBehaviour
{
    [SerializeField] List<GameObject> Pallettes;
    [SerializeField] List<GameObject> ToolButtons;
    
    public void ActivatePallete(int index){
        Pallettes[index].SetActive(true);
    }
}
