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
    [SerializeField] private GameObject _imageDesk;
    [SerializeField] private Transform _startDeskPoint;
    [SerializeField] private Transform _endDeskPoint;
    [SerializeField] private float _timeTypeSymbolDefault;
    [SerializeField] private float _timeTypeSymbolSpeedUp;
    [SerializeField] private float _speedOfDesk;
    private float _epsilone = 4;
    private float _timeTypeSymbolCurrent;
    private int _unlockedLevels;
    private int _index;
    private bool _isWriting;
    private bool _isGoRight;
    private bool _isGoLeft;

    private void Start()
    {
        _isGoRight = false;
        _isGoLeft = false;
        _imageDesk.transform.position = _startDeskPoint.position;
        _timeTypeSymbolCurrent = _timeTypeSymbolDefault;
        _isWriting = false;
        SetMessage(0);
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))///////////////////11111111111111111111111111111111111111111
        {
            if (_isWriting) _timeTypeSymbolCurrent = _timeTypeSymbolSpeedUp;
            else SetMessage(_index + 1);
            //_imageMadam.SetActive(false);
        }
        if (_isGoLeft) _imageDesk.transform.position = Vector3.Lerp(_imageDesk.transform.position, _endDeskPoint.position, Time.deltaTime * _speedOfDesk);
        if (_isGoRight) _imageDesk.transform.position = Vector3.Lerp(_imageDesk.transform.position, _startDeskPoint.position, Time.deltaTime * _speedOfDesk);
        if (System.Math.Abs(_startDeskPoint.position.x - _imageDesk.transform.position.x) < _epsilone) 
        { 
            _imageDesk.transform.position = _startDeskPoint.position;
            _isGoRight = false;
        }
        if (System.Math.Abs(_endDeskPoint.position.x - _imageDesk.transform.position.x) < _epsilone) 
        { 
            _imageDesk.transform.position = _endDeskPoint.position;
            _isGoLeft = false;
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
            _imageDesk.GetComponent<Image>().sprite = ButtonOnMenuToTutorial.CurrentTutorial[_index].SpriteDesk;
            if (_imageDesk.transform.position == _startDeskPoint.position && ButtonOnMenuToTutorial.CurrentTutorial[_index].GoDesk) _isGoLeft = true;
            if (_imageDesk.transform.position == _endDeskPoint.position && ButtonOnMenuToTutorial.CurrentTutorial[_index].GoDesk) _isGoRight = true;
        }
        else
        {
            _unlockedLevels = PlayerPrefs.GetInt("UnlockedLevels");
 
            if (_unlockedLevels <= ButtonOnMenuToTutorial.CurrentTutorial.Number)
            {
                PlayerPrefs.SetInt("UnlockedLevels", ButtonOnMenuToTutorial.CurrentTutorial.Number);
            }
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