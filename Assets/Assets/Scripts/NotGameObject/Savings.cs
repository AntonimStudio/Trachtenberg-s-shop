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
            PlayerPrefs.SetInt("UnlockedLevels", -1);
        }
        if (!PlayerPrefs.HasKey("UnlockedTutorials"))
        {
            PlayerPrefs.SetInt("UnlockedTutorials", 0);
        }
        PlayerPrefs.SetInt("UnlockedLevels", 27);
    }
}
