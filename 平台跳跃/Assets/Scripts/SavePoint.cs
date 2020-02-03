using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    public GameObject player;
    public GameObject UI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Player")
        {
            int max = player.GetComponent<PlayerStatus>().awards.Count;
            for (int i = 0; i < max; i++)
            {
                Destroy(player.GetComponent<PlayerStatus>().awards[0]);
                player.GetComponent<PlayerStatus>().awards.RemoveAt(0);
                player.GetComponent<PlayerStatus>().score++;
                UI.GetComponent<UIController>().scoreText.text = "score:" + player.GetComponent<PlayerStatus>().score;
            }
        }
    }
}
