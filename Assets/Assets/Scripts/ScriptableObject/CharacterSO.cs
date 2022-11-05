using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "ScriptableObjects/Character")]
public class CharacterSO : ScriptableObject
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private string[] _startMessages;
    [SerializeField] private string[] _questionMessages;
    [SerializeField] private string[] _goodResultMessages;
    [SerializeField] private string[] _badResultMessages;
    [SerializeField] private ListOfWords _items;
    [SerializeField] private ListOfWords _valutes;

    public Sprite Sprite => _sprite;
    public string[] StartMessages => _startMessages;
    public string[] QuestionMessages => _questionMessages;
    public string[] GoodResultMessages => _goodResultMessages;
    public string[] BadResultMessages => _badResultMessages;
    public ListOfWords Items => _items;
    public ListOfWords Valutes => _valutes;

    public string GetRandomStartMessage() => StartMessages[Random.Range(0, StartMessages.Length)];
    public string GetRandomQuestionMessage(int x, int y) => ParseString(QuestionMessages[Random.Range(0, QuestionMessages.Length)],
        Items.GetRandomWord(), Valutes.GetRandomWord(), x, y); //x всегда количество итемов, y всегда количество валюты
    public string GetRandomGoodResultMessage() => GoodResultMessages[Random.Range(0, GoodResultMessages.Length)];
    public string GetRandomBadResultMessage() => BadResultMessages[Random.Range(0, BadResultMessages.Length)];

    private string ParseString(string message, Word item, Word valute, int x, int y)
    {
        message = message.Replace("i", item.GetWord(x));
        message = message.Replace("v", valute.GetWord(y));
        message = message.Replace("x", x.ToString());
        message = message.Replace("y", y.ToString());
        return message;
    }
}
