using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Move
{
    
    public bool touch;
    public bool right;
    public float v;
    public int timer;
    public int round;

    // Update is called once per frame
    public virtual void EnemyMove(int round, ref int timer, ref bool right, float v){
        (timer)++;
        if (timer == round)
        {
            timer = 0;
            right = !right;
        }
        if (right)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(v, GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-v, GetComponent<Rigidbody2D>().velocity.y);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Player")
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
            touch = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            touch = false;
        }   
    }
}
