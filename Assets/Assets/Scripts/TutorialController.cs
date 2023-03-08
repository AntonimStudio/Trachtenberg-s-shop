using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class TutorialController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private GameObject _imageMadam;
    [SerializeField] private GameObject _imageDialog;
    [SerializeField] private float _timeTypeSymbolDefault;
    [SerializeField] private float _timeTypeSymbolSpeedUp;
    private float _timeTypeSymbolCurrent;
    private string _unlockedLevels;
    private int _index;
    private bool _isWriting;

    private void Start()
    {
        _timeTypeSymbolCurrent = _timeTypeSymbolDefault;
        _isWriting = false;
         SetMessage(0);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_isWriting) _timeTypeSymbolCurrent = _timeTypeSymbolSpeedUp;
            else SetMessage(_index + 1);
        }
    }

    private void SetMessage(int newIndex)
    {
        if (newIndex < ButtonOnMenuToTutorial.CurrentTutorial.CountMessages)
        {
            _index = newIndex;
            StartCoroutine(TypingText(ButtonOnMenuToTutorial.CurrentTutorial[_index].Message));
            _imageMadam.GetComponent<Image>().sprite = ButtonOnMenuToTutorial.CurrentTutorial[_index].SpriteCharacter;
            _imageDialog.GetComponent<Image>().sprite = ButtonOnMenuToTutorial.CurrentTutorial[_index].SpriteDialog;
        }
        else
        {
            _unlockedLevels = PlayerPrefs.GetString("UnlockedLevels");
            _unlockedLevels = _unlockedLevels.Remove(ButtonOnMenuToTutorial.CurrentTutorial.Number, 1);
            _unlockedLevels = _unlockedLevels.Insert(ButtonOnMenuToTutorial.CurrentTutorial.Number, "1");
            PlayerPrefs.SetString("UnlockedLevels", _unlockedLevels);
            SceneManager.LoadScene(2);
        }
    }

    private IEnumerator TypingText(string text)
    {
        _isWriting = true;
        _text.text = "";

        for (int i = 0; i < text.Length; i++)
        {
            _text.text += text[i];
            yield return new WaitForSeconds(_timeTypeSymbolCurrent);
        }
        _isWriting = false;
        _timeTypeSymbolCurrent = _timeTypeSymbolDefault;
        yield return null;
    }
}