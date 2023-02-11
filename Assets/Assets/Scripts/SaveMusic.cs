using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveMusic : MonoBehaviour
{
    private new AudioSource audio;
    [SerializeField] private string createdTag;

    void Awake()
    {
        GameObject obj = GameObject.FindWithTag(createdTag);
        
        if (obj != null)
        { 
            Destroy(gameObject); 
        }
        else
        {
            gameObject.tag = createdTag;
            DontDestroyOnLoad(gameObject);
        }

        audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            Destroy(gameObject);
        }
    }
}
