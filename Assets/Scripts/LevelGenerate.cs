using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerate : MonoBehaviour
{
    [SerializeField]
    private GameObject brick;
    private Transform endPoint;

    private void Awake()
    {
        endPoint = transform.GetChild(0);
    }
    public void Generate()
    {
        GameObject nextBrick = Instantiate(brick, transform.parent);
        nextBrick.transform.position = transform.position - new Vector3(0f, 0.75f, 0f);

    }
}
