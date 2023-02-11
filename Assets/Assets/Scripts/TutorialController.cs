using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class TutorialController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private SpriteRenderer _spriteMadam;
    [SerializeField] private GameObject _imageDialog;
    [SerializeField] private float _timeTypeSymbol;
    private string _unlockedLevels;

    private int _index;
    private bool _canClick;

    private void Start()
    {
        SetMessage(0);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _canClick)
        {
            SetMessage(_index + 1);
        }
    }

    private void SetMessage(int newIndex)
    {
        _canClick = false;

        if (newIndex < ButtonOnMenuToTutorial.CurrentTutorial.CountMessages)
        {
            _index = newIndex;
            StartCoroutine(TypingText(ButtonOnMenuToTutorial.CurrentTutorial[_index].Message));
            _spriteMadam.sprite = ButtonOnMenuToTutorial.CurrentTutorial[_index].SpriteCharacter;
            _imageDialog.GetComponent<Image>().sprite = ButtonOnMenuToTutorial.CurrentTutorial[_index].SpriteDialog;
        }
        else
        {
            _unlockedLevels = PlayerPrefs.GetString("UnlockedLevels");
            Debug.Log(_unlockedLevels);
            _unlockedLevels = _unlockedLevels.Remove(0, 1);
            _unlockedLevels = _unlockedLevels.Insert(0, "1");
            PlayerPrefs.SetString("UnlockedLevels", _unlockedLevels);
            Debug.Log(_unlockedLevels);
            SceneManager.LoadScene(2);
        }
    }

    private IEnumerator TypingText(string text)
    {
        _text.text = "";
        WaitForSeconds timeWait = new WaitForSeconds(_timeTypeSymbol);

        for (int i = 0; i < text.Length; i++)
        {
            _text.text += text[i];
            yield return timeWait;
        }

        _canClick = true;
        yield return null;
    }
}