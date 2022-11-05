using UnityEngine;

[CreateAssetMenu(fileName = "Words", menuName = "ScriptableObjects/Words")]
public class ListOfWords : ScriptableObject
{
    [SerializeField] private Word[] _words;

    public Word GetRandomWord() => _words[Random.Range(0, _words.Length)];
}
