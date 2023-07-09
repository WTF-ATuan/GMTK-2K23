using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] GameObject[] hearts;
    [SerializeField] int heartCount;
    private bool dead;

    private void Update()
    {
        if (dead == true)
        {
            //set dead code and animation
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Damage"))
        {
            heartCount--;
            Destroy(hearts[heartCount].gameObject);
            if (heartCount < 1)
            {
                dead = true;
            }
        }
    }
}
