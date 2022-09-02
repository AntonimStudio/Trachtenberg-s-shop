using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private GameObject point1;
    [SerializeField] private GameObject point2;
    private Vector3 beginPos;
    private Vector3 endPos;
    [SerializeField] private float time = 2;

    void Start()
    {
        beginPos = new Vector3(point1.transform.position.x, point1.transform.position.y, 0);
        endPos = new Vector3(point2.transform.position.x, point2.transform.position.y, 0);
        StartCoroutine(Move(beginPos, endPos, time));
    }

    IEnumerator Move(Vector3 beginPos, Vector3 endPos, float time)
    {
        for (float t = 0; t < 1; t += Time.deltaTime / time)
        {
            transform.position = Vector3.Lerp(beginPos, endPos, t);
            yield return null;
        }
    }
}