using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class ButtonOnMenuToTutorial : MonoBehaviour
{
    public static TutorialSettings CurrentTutorial { get; private set; }

    [SerializeField] private TutorialSettings _tutorial;
    [SerializeField] private Button _button;
    [SerializeField] public int _numberTutorial;
    [SerializeField] private int _numberScene;
    private string _unlockedTutorials;

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
        _unlockedTutorials = PlayerPrefs.GetString("UnlockedTutorials");
    }

    private void OnClick()
    {
        if (_unlockedTutorials[_numberTutorial] == '1')
        {
            CurrentTutorial = _tutorial;
            SceneManager.LoadScene(_numberScene);
        }
        
    }
}
