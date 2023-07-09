using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);

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
        if(collision.gameObject.CompareTag("Finish"))
        {
            dead = true;
        }
    }
}
