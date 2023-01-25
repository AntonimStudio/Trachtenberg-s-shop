using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Market : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    void Start()
    {
        _text.text = $"Tips: {PlayerPrefs.GetInt("Tips")}";
    }
}
