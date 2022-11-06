using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ListOfLevels", menuName = "ScriptableObjects/ListOfLevels")]
public class ListOfLevels : ScriptableObject
{
    [SerializeField] private List<LevelSettings> _levels;

    public IReadOnlyList<LevelSettings> Levels => _levels;
}
