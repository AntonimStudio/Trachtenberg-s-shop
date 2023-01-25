using TMPro;
using UnityEngine;

public class WindowEndGame : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Buyer _buyer;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private CanvasGroup _group;

    private void OnEnable()
    {
        _buyer.EndedLevel += OnEndedLevel;
    }

    private void OnDisable()
    {
        _buyer.EndedLevel -= OnEndedLevel;        
    }

    private void OnEndedLevel()
    {
        _group.alpha = 1;
        _group.interactable = true;
        _group.blocksRaycasts = true;
        string res = "";
        res += _player.CountBuyers + "\n" + "\n" + "\n";
        res += _player.CountBuyers - _player.CountWrongBuyers + "\n" + "\n" + "\n";
        res += _player.CountWrongBuyers + "\n" + "\n" + "\n";
        res += _player.Tips;
        PlayerPrefs.SetInt("Tips", PlayerPrefs.GetInt("Tips") + _player.Tips);
        PlayerPrefs.Save();
        _text.text = res;
    }
}
