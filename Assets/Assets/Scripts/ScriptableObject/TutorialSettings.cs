using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Tutorial", menuName = "ScriptableObjects/Tutorial")]
public class TutorialSettings : ScriptableObject
{
    [SerializeField] private int _number;
    [SerializeField] private StepInTutorial[] _messages;

    public int Number => _number;
    public int CountMessages => _messages.Length;

    public StepInTutorial this[int i]
    {
        get
        {
            return _messages[i];
        }
    }
}

[Serializable]
public class StepInTutorial
{
    [SerializeField] private string _message;
    [SerializeField] private Sprite _spriteCharacter;
    [SerializeField] private Sprite _spriteDialog;

    public string Message => _message;
    public Sprite SpriteCharacter => _spriteCharacter;
    public Sprite SpriteDialog => _spriteDialog;

    public StepInTutorial(string message, Sprite spriteCharacter, Sprite spriteDialog)
    {
        _message = message;
        _spriteCharacter = spriteCharacter;
        _spriteDialog = spriteDialog;
    }
}