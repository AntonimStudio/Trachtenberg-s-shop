using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonsTable : MonoBehaviour
{
    [SerializeField] private Buyer _buyer;
    [SerializeField] private TextMeshProUGUI _answerText;
    [SerializeField] private CanvasGroup _group;
    [SerializeField] private ResponseTimer _timer;
    [SerializeField] private Transform _inputImage;
    [SerializeField] private Transform _inputPointPosition;
    [SerializeField] private float _shiftAfterOverfillAnswer;
    [SerializeField] private float _countSymbolsOverfillAnswer;
    [SerializeField, Range(1, 100)] private int _maxLengthAnswer;

    private ButtonsTableState _state;
    private string _result;
    private Vector3 _inputImageDefaultPosition;
    

    public event Action AllowedClick;
    public event Action BannedClick;

    private void OnEnable()
    {
        _buyer.StartedStay += OnStartedStay;
        _buyer.EndedDialog += OnEndedDialog;
    }

    private void OnDisable()
    {
        _buyer.StartedStay -= OnStartedStay;
        _buyer.EndedDialog -= OnEndedDialog;
    }

    private void Start()
    {

        _inputImageDefaultPosition = _inputImage.position;
        OffTable();
        BannedClick?.Invoke();
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0) && _state == ButtonsTableState.WaitClickOnScreen)
        {
            _state = ButtonsTableState.WaitInput;
            _group.interactable = true;
            _buyer.OnAsk();
            _timer.OnTimer();
            AllowedClick?.Invoke();
        }
    }

    public void TakeInformation(TypeButton type)
    {
        switch (type)
        {
            case TypeButton.Ok:
                _buyer.TakeAnswer(_result);
                _state = ButtonsTableState.Forbidden;
                BannedClick?.Invoke();
                break;
            case TypeButton.Cancel:
                _result = _result.Remove(0,1);
                break;
            default:
                if(_result.Length < _maxLengthAnswer)
                    _result = ((int)type).ToString() + _result;
                break;
        }
        _answerText.text = _result;
        if (_result.Length >= _countSymbolsOverfillAnswer)
            {
                _inputImage.transform.position = _inputImageDefaultPosition - new Vector3(_shiftAfterOverfillAnswer * Screen.width * (_result.Length- _countSymbolsOverfillAnswer), 0, 0);
            }
    }

    private void OffTable()
    {
        _group.interactable = false;
        _result = "";
        _inputImage.transform.position = _inputImageDefaultPosition;
        _answerText.text = _result.ToString();
    }

    private void OnStartedStay()
    {
        _timer.FillTimer();
        _state = ButtonsTableState.WaitClickOnScreen;
    }

    private void OnEndedDialog()
    {
        OffTable();
    }
}

public enum ButtonsTableState
{
    Forbidden,
    WaitClickOnScreen,
    WaitInput
}