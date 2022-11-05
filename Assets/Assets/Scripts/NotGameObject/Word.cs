using System;
using UnityEngine;

[Serializable]
public class Word
{
    [SerializeField] private string _word1Group;
    [SerializeField] private string _word2Group;
    [SerializeField] private string _word3Group;

    public Word(string word1Group, string word2Group, string word3Group)
    {
        _word1Group = word1Group;
        _word2Group = word2Group;
        _word3Group = word3Group;
    }

    public string GetWord(int count)
    {
        if (count % 10 == 1 && count % 100 / 10 != 1)
            return _word1Group;
        else if (count % 10 >= 2 && count % 10 <= 4 && count % 100 / 10 != 1)
            return _word2Group;
        else
            return _word3Group;
    }
}
