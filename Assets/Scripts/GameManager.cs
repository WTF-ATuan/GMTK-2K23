using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int point;
    float timer;
    float cd;
    public TextMeshProUGUI pointText;
    // Start is called before the first frame update
    void Start()
    {
        cd = 2;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            timer = cd;
            point += 10;
        }

        pointText.text = point.ToString();
    }
}
