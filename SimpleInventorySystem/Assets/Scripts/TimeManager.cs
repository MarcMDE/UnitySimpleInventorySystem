using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimeManager : MonoBehaviour
{
    const int maxTime = 24;

    [SerializeField]
    UnityEvent onTimeChange = new UnityEvent();
    
    int time = 0;
    public int Hour { get { return time; } }


    public void Increase(int n=1)
    {
        time += n;
        time %= maxTime;

        onTimeChange.Invoke();
    }
}
