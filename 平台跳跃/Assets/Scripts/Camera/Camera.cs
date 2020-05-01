using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject player;
    public float speed = 0.015f;
    public float targetSpeed;
    public float updateSpeed;
    public float a = 0.01f;
    private void Start()
    {
        transform.SetPositionAndRotation(new Vector3(0, 0, transform.position.z), Quaternion.identity);
        updateSpeed = targetSpeed = speed;
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        if ((player.GetComponent<PlayerController>().onground || player.GetComponent<PlayerController>().onwall)&&player.transform.position.y>transform.position.y)
        {
            targetSpeed = speed + a * (player.transform.position.y - transform.position.y);
        }
        else if (player.transform.position.y < transform.position.y)
        {
            targetSpeed = speed;
        }
        updateSpeed += (targetSpeed - updateSpeed) / 30;
        transform.SetPositionAndRotation(transform.position + new Vector3(0, updateSpeed, 0), Quaternion.identity);
    }
}
