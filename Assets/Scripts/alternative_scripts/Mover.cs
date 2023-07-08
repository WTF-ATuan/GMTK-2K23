using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// a code for a character who will change directions depending on a time interval set in the game
/// </summary>

public class Mover : MonoBehaviour
{
    #region Fields

    [SerializeField] float moveSpeed = 0f; // speed at which a character will move
    [SerializeField] float health = 0f;    // health a character will have
    [SerializeField] float dirchange_lower = 0f; // seconds after which the person changes direction
    [SerializeField] float dirchange_upper = 0f; // upper limit
    [SerializeField] float dir = 0f; // the direction in which our guy will move, -1 is left and 1 is right

    #endregion

    Timer Dir_changer;

    #region Methods
    ///
    /// will run at start of script
    ///
    void Start()
    {
        // create timer
        Dir_changer = gameObject.AddComponent<Timer>();
        Dir_changer.Duration = dirchange_lower; // value depends on character

        //transform.Translate( moveSpeed * dir ,0 ,0);

        // start timer
        Dir_changer.Run();
    }

    ///
    /// will run every frame
    ///
    void Update()
    {
        // set initial direction and motion
        transform.Translate(moveSpeed * dir, 0, 0);

        if(Dir_changer.Finished)
        {
            dir = dir * -1; 
            //transform.Translate(movespeed * dir, 0, 0);

            // reset timer and run it again
            Dir_changer.Duration = Random.Range(dirchange_lower, dirchange_upper);
            Dir_changer.Run();
        }
    }
    #endregion
}