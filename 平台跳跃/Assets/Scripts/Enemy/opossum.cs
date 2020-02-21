using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opossum : Enemy
{
    private void Start()
    {
        touch = false;
        right = true;
        v = 1;
        timer = 0;
        round = 80;
    }
    // Update is called once per frame
    void Update()
    {
        EnemyMove(round,ref timer,ref right,v);
        ChangeDirection(-1);
    }
    
}
