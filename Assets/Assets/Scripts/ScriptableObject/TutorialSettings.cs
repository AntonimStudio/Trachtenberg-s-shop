using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Tutorial", menuName = "ScriptableObjects/Tutorial")]
public class TutorialSettings : ScriptableObject
{
    [SerializeField] private StepInTutorial[] _messages;

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
    [SerializeField] private Sprite _sprite;

    public string Message => _message;
    public Sprite Sprite => _sprite;

    public StepInTutorial(string message, Sprite sprite)
    {
        _message = message;
        _sprite = sprite;
    }
}