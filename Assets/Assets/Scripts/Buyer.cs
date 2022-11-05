using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Buyer : MonoBehaviour
{
    [SerializeField] private CharacterSO[] _characters;
    [SerializeField] private float _speedMove;
    [SerializeField] private float _timeWaitAfterAnswer;
    [SerializeField] private Transform _questionPoint;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private TextMeshProUGUI _message;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private int _lastCharacter = -1;
    private BuyerState _state = BuyerState.GoToQuestion;

    public event Action StartedStay;

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
                    _message.text = _characters[_lastCharacter].GetRandomStartMessage();
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
        _spriteRenderer.sprite = _characters[newCharacter].Sprite;
    }

    private IEnumerator GoingToStart()
    {
        yield return new WaitForSeconds(_timeWaitAfterAnswer);
        _state = BuyerState.GoToStart;
    }

    public void OnGoToStart(bool result)
    {
        StartCoroutine(GoingToStart());
        _message.text = result ? _characters[_lastCharacter].GetRandomGoodResultMessage() : 
            _characters[_lastCharacter].GetRandomBadResultMessage();
    }

    public void OnAsk()
    {
        _message.text = _characters[_lastCharacter].GetRandomQuestionMessage(5, 21);
    }
}

public enum BuyerState
{
    GoToQuestion,
    StayOnQuestion,
    GoToStart
}