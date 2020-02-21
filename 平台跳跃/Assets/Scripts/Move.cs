using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public void ChangeDirection(int isRight){//right:1,left:-1
        if (isRight * GetComponent<Rigidbody2D>().velocity.x < 0 )
        {
            transform.rotation = Quaternion.Euler(0, -180, 0);
        }
        else if (isRight * GetComponent<Rigidbody2D>().velocity.x > 0)            
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
    
}
