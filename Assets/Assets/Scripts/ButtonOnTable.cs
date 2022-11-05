using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonOnTable : MonoBehaviour
{
    [SerializeField] private TypeButton _type;
    [SerializeField] private ButtonsTable _table;
    [SerializeField] private Button _button;

    private bool _canClick;

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
        if(_canClick)
            _table.TakeInformation(_type);
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