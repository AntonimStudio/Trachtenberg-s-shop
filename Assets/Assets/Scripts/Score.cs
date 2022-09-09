using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textScore;
    private int result = 0;
    private int x = 100;

    private void Start()
    {
        textScore.text = "0";
    }

    public void UpdateScore()
    {
        result += x;
        textScore.text = result.ToString();
    }
}
