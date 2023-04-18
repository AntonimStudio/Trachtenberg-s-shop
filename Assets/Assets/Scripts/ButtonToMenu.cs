using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonToMenu : MonoBehaviour
{
    [SerializeField] private Level _level;
    private int _unlockedTutorials;

    public void GoToMenu()
    {
        _unlockedTutorials = PlayerPrefs.GetInt("UnlockedTutorials");

        if (_unlockedTutorials <= _level.Settings.Number)
        {
            PlayerPrefs.SetInt("UnlockedTutorials", _level.Settings.Number);
        }
        SceneManager.LoadScene(2);
    }
    public void GoToEnterMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void GoToAnyMenu(int _number)
    {
        SceneManager.LoadScene(_number);
    }
}
