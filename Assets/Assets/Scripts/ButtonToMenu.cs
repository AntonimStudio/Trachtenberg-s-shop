using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonToMenu : MonoBehaviour
{
    private string _unlockedTutorials;

    public void GoToMenu()
    {
        _unlockedTutorials = PlayerPrefs.GetString("UnlockedTutorials");
        Debug.Log(_unlockedTutorials);
        _unlockedTutorials = _unlockedTutorials.Remove(ButtonOnMenuToGame.CurrentLevel.Number + 1, 1);
        _unlockedTutorials = _unlockedTutorials.Insert(ButtonOnMenuToGame.CurrentLevel.Number + 1, "1");
        PlayerPrefs.SetString("UnlockedTutorials", _unlockedTutorials);
        Debug.Log(_unlockedTutorials);
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
