using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public int blood = 5;
    public int score = 0;
    private bool isLive = true;
    public int carry = 0;
    public List<GameObject> awards = new List<GameObject>();
    public GameObject UI;
    public bool super = false;
    public bool hurting = false;
    public int hurtingTime = 100;
    private int timer = 0;
    private void Update()
    {
        if (hurting)
        {
            timer++;
            if (timer%10==0)
            {
                Color color = GetComponent<SpriteRenderer>().color;
                GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, GetComponent<SpriteRenderer>().color.a > 0.7f ? 0.5f : 1f); 
            }
            if (timer==hurtingTime)
            {
                if (blood == 0)
                {
                    Destroy(gameObject);
                }
                else
                {
                    timer = 0;
                    hurting = false;
                    getCommon();
                }    
            }
        }
    }

    public void rewriteScore()
    {
        UI.GetComponent<UIController>().scoreText.text = "score:" + score;
    }
    public void rewritelife()
    {
        UI.GetComponent<UIController>().lifeText.text = "lives:" + blood;
    }
    public void getHurt()
    {
        hurting = true;
        getSuper();
        GetComponent<PlayerStatus>().blood--;
        GetComponent<PlayerStatus>().rewritelife();
        GetComponent<PlayerStatus>().carry = 0;
        int max = GetComponent<PlayerStatus>().awards.Count;
        for (int i = 0; i < max; i++)
        {
            Destroy(GetComponent<PlayerStatus>().awards[0]);
            GetComponent<PlayerStatus>().awards.RemoveAt(0);
        }
    }
    public void getSuper()
    {
        Color color = GetComponent<SpriteRenderer>().color;
        GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, 0.5f);
        super = true;

    }
    public void getCommon()
    {
        Color color = GetComponent<SpriteRenderer>().color;
        GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, 1f);
        super = false;

    }

}
