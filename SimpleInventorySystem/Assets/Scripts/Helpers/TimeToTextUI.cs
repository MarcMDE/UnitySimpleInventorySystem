using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeToTextUI : MonoBehaviour
{
    [SerializeField] TimeManager timeManager;
    Text timeText;

    private void Start()
    {
        timeText = GetComponent<Text>();
    }

    // Quick but dirty way to display the current "hour"
    private void Update()
    {
        timeText.text = timeManager.Hour.ToString();
    }
}
