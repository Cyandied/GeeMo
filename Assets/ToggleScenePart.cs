using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleScenePart : MonoBehaviour
{
    public GameObject scenePart;

    public void onClick(){
        bool isActive = scenePart.activeInHierarchy;
        scenePart.SetActive(!isActive);
    }
}
