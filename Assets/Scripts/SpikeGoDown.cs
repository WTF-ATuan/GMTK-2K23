using DefaultNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeGoDown : MonoBehaviour
{
    public float moveDownSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0f, moveDownSpeed, 0f) * Time.deltaTime;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.GetComponentInParent<IDestroyable>())
        {
            Destroy(collision.gameObject.GetComponentInParent<IDestroyable>().gameObject);
        }

        if (collision.gameObject.GetComponentInParent<BoyMovement>())
        {
            //Trigger Death
        }
    }
}
