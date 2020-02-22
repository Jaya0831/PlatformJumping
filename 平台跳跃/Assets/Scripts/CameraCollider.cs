using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollider : MonoBehaviour
{
    public GameObject myCamera;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Transform>().SetPositionAndRotation(new Vector3(transform.position.x, myCamera.transform.position.y - 4.5f, transform.position.z), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Transform>().SetPositionAndRotation(new Vector3(transform.position.x, myCamera.transform.position.y - 4.5f, transform.position.z), Quaternion.identity);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag!="Player")
        {
            Destroy(collision.gameObject);
        }
        else
        {
            collision.gameObject.GetComponent<PlayerStatus>().hurting = true;
            collision.gameObject.GetComponent<PlayerStatus>().blood = 0;
        }
    }
}
