using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    [SerializeField] private GameObject _background;
    
    private void Start()
    {
        _background.GetComponent<Image>().sprite = ButtonOnMenuToGame.CurrentLevel.Background;
    }

    public LevelSettings Settings => ButtonOnMenuToGame.CurrentLevel;
}
