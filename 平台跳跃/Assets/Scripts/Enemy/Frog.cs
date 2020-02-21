using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : Enemy
{
    public float jump = 10;
    public float line = 0.3f;
    public int r = 4;
    public int intervalTime = 100;
    public int intervalTimer = 0;
    //检测是否进入跳动范围
    public bool isEnter = false;
    //public float low_y;
    private void Start()
    {
        touch = false;
        right = true;
        timer = 0;
        round = r;
        v = 2;
        //GetComponent<Rigidbody2D>().gravityScale = 0;
        //low_y = GetComponent<Transform>().position.y;
    }
    //改写为跳
    public override void EnemyMove(int round, ref int timer, ref bool right, float v)
    {
        intervalTimer++;
        if (intervalTimer>intervalTime)
        {
            if (timer == round)
            {
                timer = 0;
                right = !right;
            }
            if (right)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(v, jump), ForceMode2D.Impulse);
            }
            else
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(-v, jump), ForceMode2D.Impulse);
            }
            intervalTimer = 0;
            (timer)++;
        }
    }
    // Update is called once per frame
    void Update()
    {
        //if (GetComponent<Transform>().position.y<low_y)
        //{
        //    GetComponent<Rigidbody2D>().gravityScale = 0;
        //}
        //else
        //{
        //    GetComponent<Rigidbody2D>().gravityScale = 5;
        //}
        GetComponent<Animator>().SetBool("isEnter", isEnter);
        if (isEnter)
        {
            EnemyMove(round, ref timer, ref right, v);
        }
        ChangeDirection(-1);
    }
}
