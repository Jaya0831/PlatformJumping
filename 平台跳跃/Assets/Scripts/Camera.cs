using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        Vector3 vector3 = new Vector3((int)(player.transform.position.x / 8) * 8, (int)(player.transform.position.y / 5) * 5, -10);
        transform.SetPositionAndRotation(vector3  , Quaternion.identity);
    }
}
