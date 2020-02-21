using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterDeath : MonoBehaviour
{
    int timer = 0;
    public int time = 25;
    // Update is called once per frame
    void Update()
    {
        timer++;
        if (timer>time)
        {
            Destroy(gameObject);
        }
    }
}
