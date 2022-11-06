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

    private int _lastCharacter = -1;
    private (int Left, int Right) _numbersQuestion;
    private BuyerState _state = BuyerState.GoToQuestion;

    public event Action StartedStay;
    public event Action EndedDialog;

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
                    _message.text = _level.Settings.Characters[_lastCharacter].GetRandomStartMessage();
                    _messagePanel.alpha = 1;
                    StartedStay?.Invoke();
                }
                break;
            case BuyerState.GoToStart:
                transform.position = Vector3.MoveTowards(transform.position, _startPoint.position, _speedMove * Time.deltaTime);
                
                if(transform.position == _startPoint.position)
                {
                    StartAssembly();
                    _state = BuyerState.GoToQuestion;
                }
                break;
        }
    }

    public void TakeAnswer(int result)
    {
        StartCoroutine(GoingToStart());

        if (result == _numbersQuestion.Left * _numbersQuestion.Right)
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