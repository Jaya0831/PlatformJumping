using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    int timer = 0;
    int round = 360;
    // Update is called once per frame
    void Update()
    {
        timer++;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, timer % round);
    }
}
