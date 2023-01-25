using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Savings : MonoBehaviour
{
    void Start()
    {
        if (!PlayerPrefs.HasKey("Tips"))
        {
            PlayerPrefs.SetInt("Tips", 0);
        }
    }
}
