using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public GameObject camera;
    public float upDistant = 0;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Transform>().SetPositionAndRotation(new Vector3(transform.position.x, camera.transform.position.y + upDistant), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Transform>().SetPositionAndRotation(new Vector3(transform.position.x, camera.transform.position.y + upDistant), Quaternion.identity);
    }
}
