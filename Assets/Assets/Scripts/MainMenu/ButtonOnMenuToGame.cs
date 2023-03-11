using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonOnMenuToGame : MonoBehaviour
{
    public static LevelSettings CurrentLevel { get; private set; }

    [SerializeField] private ListOfLevels _listOfLevels;
    [SerializeField] private int _numberLevel;
    [SerializeField] private Button _button;
    [SerializeField] private int _numberScene;
    private int _unlockedLevels;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);
    }

    private void Start()
    {
        _unlockedLevels = PlayerPrefs.GetInt("UnlockedLevels");
    }

    private void OnClick()
    {
        if (_numberLevel <= _unlockedLevels)
        {
            CurrentLevel = _listOfLevels.Levels[_numberLevel];
            SceneManager.LoadScene(_numberScene);
        }


    }   
}
