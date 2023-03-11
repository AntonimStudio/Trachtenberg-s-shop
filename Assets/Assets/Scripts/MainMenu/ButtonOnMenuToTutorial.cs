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
    private int _unlockedTutorials;

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
        _unlockedTutorials = PlayerPrefs.GetInt("UnlockedTutorials");
    }

    private void OnClick()
    {
        if (_numberTutorial <= _unlockedTutorials)
        {
            CurrentTutorial = _tutorial;
            SceneManager.LoadScene(_numberScene);
        }
        
    }
}
