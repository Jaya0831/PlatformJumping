using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Award : MonoBehaviour
{
    public GameObject player;
    private float timer = 0;
    private int number;
    private float move;
    bool up = true;

    private enum Status
    {
        stay,
        follow
    }
    private Status status = Status.stay;
    // Update is called once per frame
    void Update()
    {
        if (status==Status.follow)
        {
            
            if (up)
            {
                timer++;
            }
            else
            {
                timer--;
            }
            timer %= 50;
            if (timer>=49)
            {
                up = false;
            }
            if (timer<=1)
            {
                up = true;
            }
            move = timer / 100f;

            Vector3 vector3 = new Vector3(player.transform.position.x + number, player.transform.position.y + move - 0.3f, -3);
            transform.SetPositionAndRotation(vector3, Quaternion.identity);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Player"&&status==Status.stay)
        {
            status = Status.follow;
            player.GetComponent<PlayerStatus>().carry++;
            player.GetComponent<PlayerStatus>().awards.Add(gameObject);
            number = player.GetComponent<PlayerStatus>().carry;
        }
    }
}
