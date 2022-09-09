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
        dialogTexts[0] = "Привет, мне нужно купить яблок по 11 рублей";
        dialogTexts[1] = "Здравствуй, мне нужно купить конфет по 11 рублей";
        dialogTexts[2] = "Здравствуй, я хочу купить ректальных свечей по 11 рублей";
        dialogTexts[3] = "Мне нужно 11 литров молока";
        dialogTexts[4] = "Хей, барыга, не продашь мне 11 жвачек?";
        dialogTexts[5] = "Hello, do you speak english? I need to buy 11 magazines";
        dialogTexts[6] = "Здравствуйте, простите, извините, мне 11 игрушечных самолетиков";
        SetText();
    }

    public void IsCorrect()
    {
        if (textInput.text == (x * 11).ToString()) 
        {
            textEquation.text = "Правильно!";
            sc.UpdateScore();
        }
        else textEquation.text = "Нет! Ты идиот! Я пошел отсюда!!!";
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
