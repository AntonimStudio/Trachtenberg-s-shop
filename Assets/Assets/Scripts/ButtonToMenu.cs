using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonToMenu : MonoBehaviour
{
    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
