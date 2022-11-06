using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private int _tips;
    private int _countBuyers;
    private int _countWrongBuyers;

    public int CountBuyers => _countBuyers;
    public int CountWrongBuyers => _countWrongBuyers;

    private void Start()
    {
        _countBuyers = 0;
        _countWrongBuyers = 0;
        _tips = 0;
        SetText();
    }

    public void TakeTips(int tips)
    {
        _tips += tips;
        _countBuyers += 1;
        SetText();
    }

    public void TakeWrongBuyer()
    {
        _countBuyers += 1;
        _countWrongBuyers += 1;
    }

    private void SetText()
    {
        _text.text = $"Tips: {_tips}";
    }
}
