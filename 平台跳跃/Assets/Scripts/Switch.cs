using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public bool isOn = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.x < -2)
            {
                isOn = true;
            }
            if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.x > 2)
            {
                isOn = false;
            }
        }
    }
    private void Update()
    {
        GetComponent<Animator>().SetBool("isOn", isOn);
    }
}
