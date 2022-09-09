using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private GameObject point1;
    [SerializeField] private GameObject point2;
    [SerializeField] private GameObject CG;
    [SerializeField] private GameObject SE;
    [SerializeField] private GameObject SN;
    private CharacterGenerator cg;
    private SetNumbers sn;
    private SetEquation se;
    private Vector3 beginPos;
    private Vector3 endPos;
    private bool timeIsOver = false;
    [SerializeField] private float time;

    void Start()
    {
        cg = CG.GetComponent<CharacterGenerator>();
        se = SE.GetComponent<SetEquation>();
        sn = SN.GetComponent<SetNumbers>();
        beginPos = new Vector3(point1.transform.position.x, point1.transform.position.y, 0);
        endPos = new Vector3(point2.transform.position.x - 10, point2.transform.position.y, 0);
        StartCoroutine(Moving(beginPos, endPos, time));
    }

    IEnumerator Moving(Vector3 beginPos, Vector3 endPos, float time)
    {
        for (float t = 0; t < 1; t += Time.deltaTime / time)
        {
            transform.position = Vector3.Lerp(beginPos, endPos, t);
            yield return null;
        }
        timeIsOver = true;
    }

    private void Update()
    {
        if (timeIsOver)
        {
            transform.position = new Vector3(point1.transform.position.x, point1.transform.position.y, 0);
            se.SetText();
            cg.ÑhangeÑharacter();
            sn.Clear();
            timeIsOver = false;
            StartCoroutine(Moving(beginPos, endPos, time));
        }
    }
}