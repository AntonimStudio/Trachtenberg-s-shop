using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonToMenu : MonoBehaviour
{
    public void GoToMenu()
    {
        SceneManager.LoadScene(1);
    }
    public void GoToEnterMenu()
    {
        SceneManager.LoadScene(0);
    }
}
