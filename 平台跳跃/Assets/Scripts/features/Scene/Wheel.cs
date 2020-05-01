using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    public GameObject player;
    private void Update()
    {
        if (player)
        {
            if (player.GetComponent<PlayerStatus>().super)
            {
                GetComponent<CircleCollider2D>().isTrigger = true;
            }
            else
            {
                GetComponent<CircleCollider2D>().isTrigger = false;
            }
        }     
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            collision.gameObject.GetComponent<PlayerStatus>().getHurt();
        }
    }
}
