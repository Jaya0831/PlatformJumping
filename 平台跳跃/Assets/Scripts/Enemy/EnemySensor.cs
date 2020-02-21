using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySensor : MonoBehaviour
{
    public GameObject enemy;
    public GameObject centre;
    public GameObject all;
    public float upDistant;
    public GameObject afterDeath;
    
    // Update is called once per frame
    void Update()
    {
        GetComponent<Transform>().SetPositionAndRotation(new Vector3(centre.GetComponent<Transform>().position.x, centre.GetComponent<Transform>().position.y + upDistant, centre.GetComponent<Transform>().position.z), Quaternion.identity);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (enemy.GetComponent<opossum>() && enemy.GetComponent<opossum>().touch == false || enemy.GetComponent<Frog>() && enemy.GetComponent<Frog>().touch == false)
        {
            if (collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<Rigidbody2D>().velocity.y < 0)
            {
                Instantiate(afterDeath, enemy.transform.position, Quaternion.identity);
                Destroy(all);
            }
        }
    }
}
