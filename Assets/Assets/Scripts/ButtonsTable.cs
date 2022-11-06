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
    private int _result;

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
                _result /= 10;
                break;
            default:
                _result = _result * 10 + (int)type;
                break;
        }

        _answerText.text = _result.ToString();
    }

    private void OffTable()
    {
        _group.interactable = false;
        _result = 0;
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