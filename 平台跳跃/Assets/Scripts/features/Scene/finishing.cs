using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishing : MonoBehaviour
{
    bool open = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            open = true;
            GetComponent<Animator>().SetBool("open", open);
            StartCoroutine(collision.GetComponent<PlayerStatus>().EnterTheDoor());

        }
    }
}
