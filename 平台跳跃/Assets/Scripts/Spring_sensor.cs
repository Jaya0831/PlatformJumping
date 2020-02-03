using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring_sensor : MonoBehaviour
{
    public GameObject spring;
    public GameObject player;
    public float a = 20;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Player")
        {
            player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            Vector2 aDir = transform.position - spring.transform.position;
            aDir = Vector2.up;
            player.GetComponent<Rigidbody2D>().AddForce(aDir * a, ForceMode2D.Impulse);
          
        }
    }
}
