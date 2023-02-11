using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonOnTable : MonoBehaviour
{
    [SerializeField] private TypeButton _type;
    [SerializeField] private ButtonsTable _table;
    [SerializeField] private Button _button;
    [SerializeField] private AudioClip _buttonSound;
    private new AudioSource audio;
    private bool _canClick;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClick);
        _table.AllowedClick += OnAllowedClick;
        _table.BannedClick += OnBannedClick;
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);
        _table.AllowedClick -= OnAllowedClick;
        _table.BannedClick -= OnBannedClick;
    }

    private void OnAllowedClick() => _canClick = true;

    private void OnBannedClick() => _canClick = false;

    private void OnClick()
    {
        if (_canClick)
        {
            
            _table.TakeInformation(_type);
            playSound(_buttonSound);
        }

    }

    private void playSound(AudioClip clip)
    {
        audio.clip = clip;
        audio.Play();
    }
}

public enum TypeButton
{
    Zero,
    One,
    Two,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Ok,
    Cancel
}