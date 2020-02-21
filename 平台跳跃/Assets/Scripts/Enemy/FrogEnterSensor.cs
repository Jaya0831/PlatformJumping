using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogEnterSensor : MonoBehaviour
{
    public GameObject frog;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Player"&&frog)
        {
            frog.GetComponent<Frog>().isEnter = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player"&&frog)
        {
            frog.GetComponent<Frog>().isEnter = false;
        }
    }
}
