using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private AudioClip _cashSound;
    private new AudioSource audio;

    private int _tips;
    private int _countBuyers;
    private int _countWrongBuyers;

    public int CountBuyers => _countBuyers;
    public int CountWrongBuyers => _countWrongBuyers;
    public int Tips => _tips;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        _countBuyers = 0;
        _countWrongBuyers = 0;
        _tips = 0;
        SetText();
    }

    public void TakeTips(int tips)
    {
        _tips += tips;
        _countBuyers += 1;
        playSound(_cashSound);
        SetText();
    }

    public void TakeWrongBuyer()
    {
        _countBuyers += 1;
        _countWrongBuyers += 1;
    }

    private void playSound(AudioClip clip)
    {
        audio.clip = clip;
        audio.Play();
    }

    private void SetText()
    {
        _text.text = $"Tips: {_tips}";
    }
}
