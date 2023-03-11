using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonToMenu : MonoBehaviour
{
    private int _unlockedTutorials;

    public void GoToMenu()
    {
        _unlockedTutorials = PlayerPrefs.GetInt("UnlockedTutorials") + 1;
        PlayerPrefs.SetInt("UnlockedTutorials", _unlockedTutorials);
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
