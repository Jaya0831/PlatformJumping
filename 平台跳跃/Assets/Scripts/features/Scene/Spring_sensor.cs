using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring_sensor : MonoBehaviour
{
    public GameObject spring;
    public float a = 20;
    bool up = false;
    private void Update()
    {
        if (spring)
        {
            GetComponent<Transform>().SetPositionAndRotation(new Vector3(spring.transform.position.x, spring.transform.position.y + 0.5f * spring.transform.localScale.y + 0.15f, transform.position.z), Quaternion.identity);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Player"&&collision.gameObject.GetComponent<Rigidbody2D>().velocity.y<0)
        {
            if (up==false)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                Vector2 aDir = transform.position - spring.transform.position;
                aDir = Vector2.up;
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(aDir * a, ForceMode2D.Impulse);
                spring.GetComponent<Transform>().localScale = new Vector3(spring.GetComponent<Transform>().localScale.x, spring.GetComponent<Transform>().localScale.y + 1f, spring.GetComponent<Transform>().localScale.z);
                spring.GetComponent<Transform>().SetPositionAndRotation(new Vector3(spring.transform.position.x, spring.transform.position.y + 0.5f, spring.transform.position.z), Quaternion.identity);
                up = true;
                StartCoroutine(Recover());
            }
            else
            {
                spring.GetComponent<Transform>().localScale = new Vector3(spring.GetComponent<Transform>().localScale.x, spring.GetComponent<Transform>().localScale.y - 1f, spring.GetComponent<Transform>().localScale.z);
                spring.GetComponent<Transform>().SetPositionAndRotation(new Vector3(spring.transform.position.x, spring.transform.position.y - 0.5f, spring.transform.position.z), Quaternion.identity);
                up = false;
            }
        }
    }
    IEnumerator Recover()
    {
        yield return new WaitForSeconds(1);
        if (up)
        {
            spring.GetComponent<Transform>().localScale = new Vector3(spring.GetComponent<Transform>().localScale.x, spring.GetComponent<Transform>().localScale.y - 1f, spring.GetComponent<Transform>().localScale.z);
            spring.GetComponent<Transform>().SetPositionAndRotation(new Vector3(spring.transform.position.x, spring.transform.position.y - 0.5f, spring.transform.position.z), Quaternion.identity);
            up = false;
        }
    }
}
