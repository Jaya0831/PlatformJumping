using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thorn : MonoBehaviour
{
    public float force = 10;
    // Update is called once per frame
    private void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            //Debug.Log("hurt!");
            if (!collision.gameObject.GetComponent<PlayerStatus>().super)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, force), ForceMode2D.Impulse);
                collision.gameObject.GetComponent<PlayerStatus>().getHurt();
            }
            
        }
    }
}
