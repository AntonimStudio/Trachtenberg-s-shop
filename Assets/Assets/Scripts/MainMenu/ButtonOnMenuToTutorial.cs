using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonOnMenuToTutorial : MonoBehaviour
{
    public static TutorialSettings CurrentTutorial { get; private set; }

    [SerializeField] private TutorialSettings _tutorial;
    [SerializeField] private Button _button;
    [SerializeField] private int _numberScene;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);
    }

    private void OnClick()
    {
        CurrentTutorial = _tutorial;
        SceneManager.LoadScene(_numberScene);
    }
}
