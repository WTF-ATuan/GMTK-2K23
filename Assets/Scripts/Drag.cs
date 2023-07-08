using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    Vector2 difference = Vector2.zero;//distance vector initialised
    private void OnMouseDown()
    {

        //Distance between mouse and abject calculated
        difference = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;
    }
    private void OnMouseDrag()
    {
        //Moving the object with the mouse
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - difference;
    }

    //Once the brick is placed, the code will be disabled for the brick so it cannot be picked up
    private void OnMouseUp()
    {
        Destroy(GetComponent<Drag>());
    }
}
