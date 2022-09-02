using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetNumbers : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textInput;
    private void Start()
    {
        textInput.text = "";
    }

    public void Set1()
    {
        textInput.text = "1" + textInput.text;
    }
    public void Set2()
    {
        textInput.text = "2" + textInput.text;
    }
    public void Set3()
    {
        textInput.text = "3" + textInput.text;
    }
    public void Set4()
    {
        textInput.text = "4" + textInput.text;
    }
    public void Set5()
    {
        textInput.text = "5" + textInput.text;
    }
    public void Set6()
    {
        textInput.text = "6" + textInput.text;
    }
    public void Set7()
    {
        textInput.text = "7" + textInput.text;
    }
    public void Set8()
    {
        textInput.text = "8" + textInput.text;
    }
    public void Set9()
    {
        textInput.text = "9" + textInput.text;
    }
    public void Set0()
    {
        textInput.text = "0" + textInput.text;
    }
    public void SetX()
    {
        textInput.text = textInput.text.Remove(0, 1);
    }
}
