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
    private string prevstroka;

    private ButtonsTableState _state;
    private string _result;

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
        OffTable();
        BannedClick?.Invoke();
        prevstroka = "";
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
                if (_inputImage.transform.position.x < _inputPointPosition.transform.position.x -32) 
                    _inputImage.transform.position = new Vector3(_inputImage.transform.position.x + 32, 
                        _inputImage.transform.position.y, _inputImage.transform.position.z);
                break;
            default:
                if (_result.Length < 14) _result = ((int)type).ToString() + _result;  /////????
                break;
        }
        _answerText.text = _result;
        if (_result.Length < 15 && prevstroka.Length < _result.Length && _result.Length > 10)
            {
                _inputImage.transform.position = new Vector3(_inputImage.transform.position.x - 32, _inputImage.transform.position.y, _inputImage.transform.position.z);
            }
        prevstroka = _result;


    }

    private void OffTable()
    {
        _group.interactable = false;
        _result = "";
        _inputImage.transform.position = new Vector3(_inputPointPosition.transform.position.x, _inputPointPosition.transform.position.y, _inputPointPosition.transform.position.z);
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