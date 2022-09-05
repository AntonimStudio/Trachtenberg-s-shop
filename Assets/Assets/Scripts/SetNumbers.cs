using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetNumbers : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textInput;
    [SerializeField] private GameObject input;
    private void Start()
    {
        textInput.text = "";
        RectTransform rt = input.GetComponent<RectTransform>();
    }

    public void SetNum(int x)
    {
        if (textInput.text.Length < 16 && textInput.text.Length > 9) 
        {
            input.GetComponent<Transform>().Translate(-40, 0, 0);
        }
        if (textInput.text.Length < 16)
        {
            textInput.text = x.ToString() + textInput.text;
        }

        if (textInput.text == "80085")
        {
            StartCoroutine(EasterEgg());
        }
    }

    public void SetX()
    {
        if (textInput.text.Length > 0)
        {
            textInput.text = textInput.text.Remove(0, 1);
        }
        if (textInput.text.Length >= 10)
        {
            input.GetComponent<Transform>().Translate(40, 0, 0);
        }
    }

    IEnumerator EasterEgg()
    {
        textInput.text = "(.)(.)";
        yield return new WaitForSeconds(0.25f);
        textInput.text = "80085";
    }
}
