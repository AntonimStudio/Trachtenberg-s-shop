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
    }

    private void OnDisable()
    {
        _buyer.StartedStay -= OnStartedStay;
    }

    private void Start()
    {
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
                _buyer.OnGoToStart(_result == 4);
                _state = ButtonsTableState.Forbidden;
                _group.interactable = false;
                _result = 0;
                _timer.ResetTimer();
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

    private void OnStartedStay()
    {
        _timer.FillTimer();
        _state = ButtonsTableState.WaitClickOnScreen;
    }
}

public enum ButtonsTableState
{
    Forbidden,
    WaitClickOnScreen,
    WaitInput
}