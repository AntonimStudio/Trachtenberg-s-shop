using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetEquation : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textInput;
    [SerializeField] private TextMeshProUGUI textEquation;
    private int x;

    void Start()
    {
        x = Random.Range(101, 1000);
        textEquation.text = x.ToString() + " * 11 = ?";
    }

    void Update()
    {
        if (textInput.text == (x * 11).ToString()) 
        {
            textEquation.text = "Correct!";
        }
    }
}
