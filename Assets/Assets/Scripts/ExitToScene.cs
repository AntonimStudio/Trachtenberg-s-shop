using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitToScene : MonoBehaviour
{
    [SerializeField] private int _numberScene;

    public void OnClick()
    {
        SceneManager.LoadScene(_numberScene);
    }
}
