using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject player;
    public float speed = 0.2f;
    private void Start()
    {
        transform.SetPositionAndRotation(new Vector3(0, 0, transform.position.z), Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
        transform.SetPositionAndRotation(transform.position + new Vector3(0, speed, 0), Quaternion.identity);
    }
}
