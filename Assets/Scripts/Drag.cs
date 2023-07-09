using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    GameObject blockInit;
    //Vector2 difference = Vector2.zero;//distance vector initialised
    //private void OnMouseDown()
    //{
    //    Debug.Log("Down");
    //    //Distance between mouse and abject calculated
    //    difference = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;
    //}
    //private void OnMouseDrag()
    //{
    //    //Moving the object with the mouse
    //    transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - difference;
    //}

    ////Once the brick is placed, the code will be disabled for the brick so it cannot be picked up
    //private void OnMouseUp()
    //{
    //    Destroy(GetComponent<Drag>());
    //}

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 direction = Input.mousePosition - Camera.main.transform.position;
            RaycastHit hit;
            Physics.Raycast(Camera.main.transform.position, direction, out hit);
            Debug.Log(hit.transform.TryGetComponent(out BlockControl block));
            if (hit.transform.TryGetComponent(out block))
            {
                blockInit = Instantiate(block.holdingBlock.summonedBlock);
            }
        }
        if(blockInit)
        {
            blockInit.transform.position = Input.mousePosition;
        }
    }
}
