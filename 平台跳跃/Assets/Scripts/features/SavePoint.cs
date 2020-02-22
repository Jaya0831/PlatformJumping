using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    public GameObject star;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Player"&&collision.gameObject.GetComponent<PlayerController>().onground)
        {
            int max = collision.gameObject.GetComponent<PlayerStatus>().awards.Count;
            for (int i = 0; i < max; i++)
            {
                Instantiate(star, collision.gameObject.transform.position, Quaternion.identity);
                Destroy(collision.gameObject.GetComponent<PlayerStatus>().awards[0]);
                collision.gameObject.GetComponent<PlayerStatus>().awards.RemoveAt(0);
                collision.gameObject.GetComponent<PlayerStatus>().score++;
            }
            collision.GetComponent<PlayerStatus>().rewriteScore();
            collision.GetComponent<PlayerStatus>().carry = 0;          
        }
    }
}
