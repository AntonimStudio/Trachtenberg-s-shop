using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Savings : MonoBehaviour
{
    [SerializeField] private int[] _lockedLevelsList;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("Tips"))
        {
            PlayerPrefs.SetInt("Tips", 0);
        }

        if (!PlayerPrefs.HasKey("UnlockedLevels"))
        {
            PlayerPrefs.SetString("UnlockedLevels", "00000000000000000000");
        }

        if (!PlayerPrefs.HasKey("UnlockedTutorials"))
        {
            PlayerPrefs.SetString("UnlockedTutorials", "10000000000000000000");
        }
    }
}
