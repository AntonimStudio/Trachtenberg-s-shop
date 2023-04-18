using System;
using UnityEngine;
using UnityEngine.UI;

public class ResponseTimer : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    private float _time;
    [SerializeField] private Level _level;

    private Timer _timer;

    public event Action EndedTimer;
    public event Action ResetedTimer;

    public float Value => 1 - _timer.Time / _timer.MaxTime;

    private void Awake()
    {
        _time = _level.Settings.Time;
    }
    private void Update()
    {
        if(_timer != null)
        {
            _timer.Tick(Time.deltaTime);

            if(_timer != null)
                _slider.value = 1 - _timer.Time / _timer.MaxTime;
        }
    }

    public void ResetTimer()
    {
        _timer.EndedTimer -= OnEndedTimer;
        _timer = null;
        _slider.value = 0;
        ResetedTimer?.Invoke();
    }

    public void FillTimer()
    {
        _slider.value = 1;
    }

    public void OnTimer()
    {
        _timer = new Timer(_time);
        _timer.EndedTimer += OnEndedTimer;
    }

    private void OnEndedTimer()
    {
        EndedTimer?.Invoke();
    }
}
