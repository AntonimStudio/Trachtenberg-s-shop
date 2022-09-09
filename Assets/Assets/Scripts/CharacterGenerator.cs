using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] characters;
    private GameObject currentCharacter;
    private Extermination ex;
    private int previousNumb;

    private void Start()
    {
        previousNumb = Random.Range(0, characters.Length);
        GameObject currentCharacter = (GameObject) Instantiate(characters[previousNumb], transform.position, Quaternion.identity);
        ex = currentCharacter.GetComponent<Extermination>();
    }

    public void —hange—haracter()
    {
        ex.Exterminate();
        CreateCharacter();
    }
    private void CreateCharacter()
    {
        int x = Random.Range(0, characters.Length);
        while (x == previousNumb)
        {
            x = Random.Range(0, characters.Length);
        }
        currentCharacter = Instantiate(characters[x], transform.position, Quaternion.identity);
        ex = currentCharacter.GetComponent<Extermination>();
        previousNumb = x;
    }
}
