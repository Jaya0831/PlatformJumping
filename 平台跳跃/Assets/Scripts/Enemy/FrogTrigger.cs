using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogTrigger : MonoBehaviour
{
    public GameObject enemy;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!collision.gameObject.GetComponent<PlayerStatus>().super)
            {
                collision.gameObject.GetComponent<PlayerStatus>().getHurt();
            }
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            enemy.GetComponent<Enemy>().touch = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            enemy.GetComponent<Enemy>().touch = false;
        }
    }
}
