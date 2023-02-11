using TMPro;
using UnityEngine;

public class WindowEndGame : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Buyer _buyer;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private CanvasGroup _group;
    [SerializeField] private AudioClip _applauseSound;
    [SerializeField] private AudioClip _disappointmentSound;
    private new AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        
    }

    private void OnEnable()
    {
        _buyer.EndedLevel += OnEndedLevel;
        
    }

    private void OnDisable()
    {
        _buyer.EndedLevel -= OnEndedLevel;        
    }

    private void playSound(AudioClip clip)
    {
        audio.clip = clip;
        audio.Play();
    }

    private void OnEndedLevel()
    {
        _group.alpha = 1;
        _group.interactable = true;
        _group.blocksRaycasts = true;
        string res = "";
        if (_player.CountBuyers >= _player.CountWrongBuyers * 2)
        {
            playSound(_applauseSound);
        }
        else playSound(_disappointmentSound);
        res += _player.CountBuyers + "\n" + "\n" + "\n";
        res += _player.CountBuyers - _player.CountWrongBuyers + "\n" + "\n" + "\n";
        res += _player.CountWrongBuyers + "\n" + "\n" + "\n";
        res += _player.Tips;
        PlayerPrefs.SetInt("Tips", PlayerPrefs.GetInt("Tips") + _player.Tips);
        PlayerPrefs.Save();
        _text.text = res;
    }
}
