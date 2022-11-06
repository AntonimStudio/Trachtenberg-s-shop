using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _background;
    
    private void Start()
    {
        _background.sprite = ButtonOnMenu.CurrentLevel.Background;
    }

    public LevelSettings Settings => ButtonOnMenu.CurrentLevel;
}
