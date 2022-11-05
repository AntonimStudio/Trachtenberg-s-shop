using UnityEngine;
using System;

public class Timer
{
    public event Action EndedTimer;

    public float Time { get; private set; }
    public float MaxTime { get; private set; }

    public Timer(float maxTime)
    {
        MaxTime = maxTime;
        Time = 0;
    }

    public void Tick(float timeSpan)
    {
        Time = Mathf.Clamp(Time + timeSpan, 0, MaxTime);

        if(Time == MaxTime)
        {
            EndedTimer?.Invoke();
        }
    }
}
