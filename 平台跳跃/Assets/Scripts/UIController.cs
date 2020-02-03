using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text scoreText;
    public Text lifeText;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "score:" + player.GetComponent<PlayerStatus>().score;
        lifeText.text = "lives:" + player.GetComponent<PlayerStatus>().blood;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
