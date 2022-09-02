using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetEquation : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textInput;
    [SerializeField] private TextMeshProUGUI textEquation;
    private int x;

    private void Start()
    {
        x = Random.Range(101, 1000);
        textEquation.text = x.ToString() + " * 11 = ?";
    }

    public void IsCorrect()
    {
        if (textInput.text == (x * 11).ToString()) 
        {
            textEquation.text = "Correct!";
        }
        else textEquation.text = "You're an IDIOT!!!!!";
    }
}
