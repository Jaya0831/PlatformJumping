using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingStage : MonoBehaviour
{
    public GameObject switch_;
    public float v = 1;
    public int round=100;
    public int timer = 0;
    bool up = false;
    Vector2 startPosition;
    // Update is called once per frame
    private void Start()
    {
        startPosition = transform.position;
    }
    void Update()
    {
        if (switch_.GetComponent<Switch>().isOn == true)
        {
            GetComponent<Rigidbody2D>().constraints = ~RigidbodyConstraints2D.FreezePositionY;
            timer++;
            if (timer>round)
            {
                timer = 0;
                up = !up;
            }
            if (up)
            {
                GetComponent<Rigidbody2D>().MovePosition(new Vector2(startPosition.x, startPosition.y - v * round + v * timer));
            }
            else
            {
                GetComponent<Rigidbody2D>().MovePosition(new Vector2(startPosition.x, startPosition.y - v * timer));
            }
        }
        else
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
}
