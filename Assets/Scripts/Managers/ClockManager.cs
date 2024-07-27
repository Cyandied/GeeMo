using System;
using TMPro;
using UnityEngine;

public class ClockManager : MonoBehaviour
{
    [SerializeField]
    private TimeManager timeManager;
    [SerializeField]
    private GameObject timeDisplay;
    [SerializeField]
    private GameObject dateDisplay;
    private TextMeshProUGUI timeTextDisplay;
    private TextMeshProUGUI dateTextDisplay;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        timeTextDisplay = timeDisplay.GetComponent<TextMeshProUGUI>();
        dateTextDisplay = dateDisplay.GetComponent<TextMeshProUGUI>();
        timeManager.TimeUpdate.AddListener(UpdateTime);
        timeManager.DateUpdate.AddListener(UpdateDate);
    }

    void UpdateTime(Time time){
        timeTextDisplay.text = time.ToString();
    }

    void UpdateDate(Date date){
        dateTextDisplay.text = date.ToString();
    }
}
