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

                _result = ((int)type).ToString() + _result;  /////????
                break;
        }
        Debug.Log(_result.ToString());
        _answerText.text = _result;
    }

    private void OffTable()
    {
        _group.interactable = false;
        _result = "";
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