using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public float speed = 5;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("2333");
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(speed, 0));
        }
    }
    
}
