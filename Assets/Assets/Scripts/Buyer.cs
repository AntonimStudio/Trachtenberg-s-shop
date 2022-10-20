using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Buyer : MonoBehaviour
{
    [SerializeField] private Sprite[] _characters;
    [SerializeField] private float _speedMove;
    [SerializeField] private float _timeWaitAfterAnswer;
    [SerializeField] private Transform _questionPoint;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private TextMeshProUGUI _message;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private int _lastCharacter = -1;
    private BuyerState _state = BuyerState.GoToQuestion;

    public event Action StartedStay;

    public string StartMessage { get; private set; } = "Привет";
    public string QuestionMessage { get; private set; } = "2*2=?";
    public string GoodResultMessage { get; private set; } = "Благодарю";
    public string BadResultMessage { get; private set; } = "Неверно!";

    private void Start()
    {
        ChooseCharacter();
    }

    private void Update()
    {
        switch (_state)
        {
            case BuyerState.GoToQuestion:
                transform.position = Vector3.MoveTowards(transform.position, _questionPoint.position, _speedMove * Time.deltaTime);

                if(transform.position == _questionPoint.position)
                {
                    _state = BuyerState.StayOnQuestion;
                    _message.text = StartMessage;
                    StartedStay?.Invoke();
                }
                break;
            case BuyerState.GoToStart:
                transform.position = Vector3.MoveTowards(transform.position, _startPoint.position, _speedMove * Time.deltaTime);
                
                if(transform.position == _startPoint.position)
                {
                    ChooseCharacter();
                    _state = BuyerState.GoToQuestion;
                }
                break;
        }
    }

    private void ChooseCharacter()
    {
        int newCharacter;

        do
        {
            newCharacter = UnityEngine.Random.Range(0, _characters.Length);
        }
        while (newCharacter == _lastCharacter);

        _lastCharacter = newCharacter;
        _spriteRenderer.sprite = _characters[newCharacter];
    }

    private IEnumerator GoingToStart()
    {
        yield return new WaitForSeconds(_timeWaitAfterAnswer);
        _state = BuyerState.GoToStart;
    }

    public void OnGoToStart(bool result)
    {
        StartCoroutine(GoingToStart());
        _message.text = result ? GoodResultMessage : BadResultMessage;
    }

    public void OnAsk()
    {
        _message.text = QuestionMessage;
    }
}

public enum BuyerState
{
    GoToQuestion,
    StayOnQuestion,
    GoToStart
}