using UnityEngine;
using UnityEngine.UI;

public class ResponseTimer : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _time;

    private Timer _timer;

    private void Update()
    {
        if(_timer != null)
        {
            _timer.Tick(Time.deltaTime);
            _slider.value = 1 - _timer.Time / _timer.MaxTime;
        }
    }

    public void ResetTimer()
    {
        _timer = null;
        _slider.value = 0;
    }

    public void FillTimer()
    {
        _slider.value = 1;
    }

    public void OnTimer()
    {
        _timer = new Timer(_time);
    }
}
