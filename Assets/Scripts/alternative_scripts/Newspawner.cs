using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Newspawner : MonoBehaviour
{
    [SerializeField] float spawnrate = 0f; // basically duration
    Timer spawner;

    
    // Start is called before the first frame update
    void Start()
    {
        spawner = gameObject.AddComponent<Timer>();
        spawner.Duration = spawnrate;
    }

    // Update is called once per frame
    void Update()
    {
        if(spawner.Finished) // the timer has been reached
        {
            // code to instantiate new block
            // must include if statements like x block has been placed
            // Instantiate(gameObject, transform.position(), transform.position())
        }
    }
}
