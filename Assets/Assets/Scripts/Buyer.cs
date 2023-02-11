using System.Collections;
using UnityEngine;
using TMPro;
using System;

public class Buyer : MonoBehaviour
{
    [SerializeField] private float _speedMove;
    [SerializeField] private float _timeWaitAfterAnswer;
    [SerializeField] private Transform _questionPoint;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private TextMeshProUGUI _message;
    [SerializeField] private CanvasGroup _messagePanel;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Level _level;
    [SerializeField] private Player _player;
    [SerializeField] private ResponseTimer _timer;
    [Space(20)]
    [Header("Настройки анимации")]
    [SerializeField] private AnimationCurve _curve;
    [SerializeField] private float _defaultY;

    private int _lastCharacter = -1;
    private int _countAnswers;
    private (int Left, int Right) _numbersQuestion;
    private BuyerState _state = BuyerState.GoToQuestion;
    private bool _endGame;

    public event Action StartedStay;
    public event Action EndedDialog;
    public event Action EndedLevel;

    private void OnEnable()
    {
        _timer.EndedTimer += OnEndedTimer;
    }

    private void OnDisable()
    {
        _timer.EndedTimer -= OnEndedTimer;
    }

    private void Start()
    {
        StartAssembly();
        _countAnswers = 0;
    }

    private void Update()
    {
        if(_endGame == false)
        {
            Vector3 newPosition;
            switch (_state)
            {
                case BuyerState.GoToQuestion:
                    newPosition = new Vector3();
                    newPosition.x = Mathf.MoveTowards(transform.position.x, _questionPoint.position.x, _speedMove * Time.deltaTime);
                    newPosition.y = _defaultY + _curve.Evaluate((newPosition.x-_startPoint.position.x)/(_questionPoint.position.x- _startPoint.position.x));
                    newPosition.z = transform.position.z;
                    transform.position = newPosition;

                    if (transform.position.x == _questionPoint.position.x)
                    {
                        _state = BuyerState.StayOnQuestion;
                        _message.text = _level.Settings.Characters[_lastCharacter].GetRandomStartMessage();
                        _messagePanel.alpha = 1;
                        StartedStay?.Invoke();
                    }
                    break;
                case BuyerState.GoToStart:
                    newPosition = new Vector3();
                    newPosition.x = Mathf.MoveTowards(transform.position.x, _startPoint.position.x, _speedMove * Time.deltaTime);
                    newPosition.y = _defaultY + _curve.Evaluate(1 - (newPosition.x - _questionPoint.position.x) / (_startPoint.position.x - _questionPoint.position.x));
                    newPosition.z = transform.position.z;
                    transform.position = newPosition;

                    if (transform.position.x == _startPoint.position.x)
                    {
                        if(_countAnswers >= _level.Settings.CountQuestions)
                        {
                            _endGame = true;
                            EndedLevel?.Invoke();
                        }
                        else
                        {
                            StartAssembly();
                            _state = BuyerState.GoToQuestion;
                        }
                    }
                    break;
            }
        }   
    }

    public void TakeAnswer(string result)
    {
        StartCoroutine(GoingToStart());

        if (result == (_numbersQuestion.Left * _numbersQuestion.Right).ToString())
        {
            _message.text = _level.Settings.Characters[_lastCharacter].GetRandomGoodResultMessage();
            _player.TakeTips(Mathf.RoundToInt(_timer.Value * 100));
        }
        else
        {
            _message.text = _level.Settings.Characters[_lastCharacter].GetRandomBadResultMessage();
            _player.TakeWrongBuyer();
        }
        _timer.ResetTimer();
        _countAnswers++;
    }

    public void OnAsk()
    {
        _message.text = _level.Settings.Characters[_lastCharacter].GetRandomQuestionMessage(_numbersQuestion.Left, _numbersQuestion.Right);
    }

    private void OnEndedTimer()
    {
        StartCoroutine(GoingToStart());
        _message.text = _level.Settings.Characters[_lastCharacter].GetRandomBadResultMessage();
        _timer.ResetTimer();
        _player.TakeWrongBuyer();
        _countAnswers++; //!!!!!!!!!!!
    }

    private void StartAssembly()
    {
        ChooseCharacter();
        _numbersQuestion.Left = _level.Settings.GetLeftRandomValue();
        _numbersQuestion.Right = _level.Settings.GetRightRandomValue();
    }

    private void ChooseCharacter()
    {
        int newCharacter;

        do
        {
            newCharacter = UnityEngine.Random.Range(0, _level.Settings.Characters.Count);
        }
        while (newCharacter == _lastCharacter);

        _lastCharacter = newCharacter;
        _spriteRenderer.sprite = _level.Settings.Characters[newCharacter].Sprite;
    }

    private IEnumerator GoingToStart()
    {
        EndedDialog?.Invoke();
        yield return new WaitForSeconds(_timeWaitAfterAnswer);
        _messagePanel.alpha = 0;
        _state = BuyerState.GoToStart;
    }
}

public enum BuyerState
{
    GoToQuestion,
    StayOnQuestion,
    GoToStart
}