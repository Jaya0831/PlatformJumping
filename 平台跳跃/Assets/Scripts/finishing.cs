using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishing : MonoBehaviour
{
    public GameObject star;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Player")
        {

        }
        Instantiate(star, collision.gameObject.transform.position, Quaternion.identity);
    }
}
