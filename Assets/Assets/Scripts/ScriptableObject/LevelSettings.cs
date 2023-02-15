using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/Levels")]
public class LevelSettings : ScriptableObject
{
    [SerializeField] private int _number;
    [SerializeField] private List<int> _leftValues;
    [SerializeField] private int _minRightValue;
    [SerializeField] private int _maxRightValue;
    [SerializeField] private List<CharacterSO> _characters;
    [SerializeField] private Sprite _backgroung;
    [SerializeField] private int _countQuestions;

    public int Number => _number;
    public int GetLeftRandomValue() => _leftValues[Random.Range(0, _leftValues.Count)];
    public int GetRightRandomValue() => Random.Range(_minRightValue, _maxRightValue + 1);
    public int CountQuestions => _countQuestions;
    public IReadOnlyList<CharacterSO> Characters => _characters;
    public Sprite Background => _backgroung;
    
}
