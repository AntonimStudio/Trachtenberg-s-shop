using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetEquation : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textInput;
    [SerializeField] private TextMeshProUGUI textEquation;
    [SerializeField] private GameObject score;
    private Score sc;
    private string[] dialogTexts = new string[7];
    private int x;

    private void Start()
    {
        sc = score.GetComponent<Score>();
        dialogTexts[0] = "������, ��� ����� ������ ����� �� 11 ������";
        dialogTexts[1] = "����������, ��� ����� ������ ������ �� 11 ������";
        dialogTexts[2] = "����������, � ���� ������ ���������� ������ �� 11 ������";
        dialogTexts[3] = "��� ����� 11 ������ ������";
        dialogTexts[4] = "���, ������, �� ������� ��� 11 ������?";
        dialogTexts[5] = "Hello, do you speak english? I need to buy 11 magazines";
        dialogTexts[6] = "������������, ��������, ��������, ��� 11 ���������� �����������";
        SetText();
    }

    public void IsCorrect()
    {
        if (textInput.text == (x * 11).ToString()) 
        {
            textEquation.text = "���������!";
            sc.UpdateScore();
        }
        else textEquation.text = "���! �� �����! � ����� ������!!!";
    }
    
    public void SetText()
    {
        textEquation.text = dialogTexts[Random.Range(0, dialogTexts.Length)];
        StartCoroutine(SettingText());
    }
    
    public IEnumerator SettingText()
    {
        yield return new WaitForSeconds(3.5f);
        x = Random.Range(101, 1000);
        textEquation.text = x.ToString() + " * 11 = ?";
    }
}
