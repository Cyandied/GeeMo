using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    public int targetScene;
    void OnMouseDown(){
        SceneManager.LoadScene(targetScene);
        Scene scene =SceneManager.GetSceneByBuildIndex(targetScene);
        SceneManager.SetActiveScene(scene);
    }
}
