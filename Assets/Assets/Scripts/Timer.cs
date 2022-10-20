using UnityEngine;
using System;

public class Timer
{
    private float _time;
    private float _maxTime;

    public event Action EndedTimer;

    public Timer(float maxTime)
    {
        _maxTime = maxTime;
        _time = 0;
    }

    public void Tick(float timeSpan)
    {
        _time = Mathf.Clamp(_time + timeSpan, 0, _maxTime);

        if(_time == _maxTime)
        {
            EndedTimer?.Invoke();
        }
    }
}
