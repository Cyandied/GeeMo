using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigationManager : MonoBehaviour
{
    public List<Place> Places;
    public GameObject PersistantUI;
    Dictionary<String,Place> placeLookup;
    public String startGameOnScene;
    public GameObject LoadingScreen;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        placeLookup = new Dictionary<string, Place>();
        foreach(Place place in Places){
            placeLookup.Add(place.SceneName,place);
        }
    }

    void Start(){
        SendToScene(startGameOnScene);
    }


    public void SendToScene(String SceneName){
        StartCoroutine(loadScene(SceneName));
        // SceneManager.SetActiveScene(SceneManager.GetSceneByName(startGameOnScene));
        PersistantUI.SetActive(placeLookup[startGameOnScene].PersistantUI);
    }

    IEnumerator loadScene(String sceneName){
        LoadingScreen.SetActive(true);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        while (!asyncLoad.isDone)
        {
            // Here you can communicate the progress to the player
            // e.g., a loading bar
            yield return null;
        }
        LoadingScreen.SetActive(false);
    }
}