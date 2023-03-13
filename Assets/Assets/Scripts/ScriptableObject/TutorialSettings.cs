using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Tutorial", menuName = "ScriptableObjects/Tutorial")]
public class TutorialSettings : ScriptableObject
{
    [SerializeField] private int _number;
    [SerializeField] private StepInTutorial[] _messages;
    public int CountMessages => _messages.Length;

    public StepInTutorial this[int i]
    {
        get
        {
            return _messages[i];
        }
    }

    public int Number => _number;


}

[Serializable]
public class StepInTutorial
{
    [SerializeField] private string _message;
    [SerializeField] private Sprite _spriteCharacter;
    [SerializeField] private Sprite _spriteDialog;
    [SerializeField] private Sprite _spriteDesk;
    [SerializeField] private Boolean _GoDesk;

    public string Message => _message;
    public Sprite SpriteCharacter => _spriteCharacter;
    public Sprite SpriteDialog => _spriteDialog;
    public Sprite SpriteDesk => _spriteDesk;
    public Boolean GoDesk => _GoDesk;

    public StepInTutorial(string message, Sprite spriteCharacter, Sprite spriteDialog, Sprite spriteDesk, Boolean GoDesk)
    {
        _message = message;
        _spriteCharacter = spriteCharacter;
        _spriteDialog = spriteDialog;
        _spriteDesk = spriteDesk;
        _GoDesk = GoDesk;
    }
}