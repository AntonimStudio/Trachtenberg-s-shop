using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonToMenu : MonoBehaviour
{

    public void GoToMenu()
    {
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
