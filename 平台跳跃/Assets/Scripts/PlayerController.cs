using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerRigidbody;
    Collider2D playerCollider;
    Vector2 moveDir;
    public float speedForMove = 80;
    public float speedForJumpHorizontal = 40;
    public float speedForJumpVertical = 20;
    public float speedForDash = 80;
    public float line=1;
    public float g = 20;
    [Range(-5, 5)]
    public float v;

    private void Start()
    {
        playerCollider = GetComponent<Collider2D>();
        playerRigidbody = GetComponent<Rigidbody2D>();


    }
    void Update()
    {
        moveDir.x = Input.GetAxis("Horizontal");
        moveDir.y = Input.GetAxis("Jump");
        moveDir = moveDir.normalized;
        //move
        if (moveDir.y>=-0.01&&moveDir.y<=0.01)
        {
            playerRigidbody.gravityScale = g;
            playerRigidbody.velocity = moveDir * speedForMove;
        }
        //jump
        if (Physics2D.Raycast(transform.position, Vector2.down, 1.3f, 1 << LayerMask.NameToLayer("ground"))&&playerRigidbody.velocity.y<=0.01&& playerRigidbody.velocity.y >= -0.01)
        {
            
            playerRigidbody.gravityScale = g;
            if (moveDir.y > 0.01 || moveDir.y < -0.01)
            {
                Vector2 vector2 = new Vector2(moveDir.x * speedForJumpVertical, moveDir.y * speedForJumpHorizontal);
                playerRigidbody.AddForce(vector2, ForceMode2D.Impulse);
                
            }
        }
        //climb
        if (Physics2D.Raycast(transform.position, Vector2.right, 1.05f, 1 << LayerMask.NameToLayer("wall"))|| Physics2D.Raycast(transform.position, Vector2.left, 1.05f, 1 << LayerMask.NameToLayer("wall")))
        {
            if (Input.GetKey(KeyCode.Q))
            {
                playerRigidbody.gravityScale = 0;
            }
            else
            {
                playerRigidbody.gravityScale = g;
            }
        }
        if (playerRigidbody.gravityScale<=0.1&&playerRigidbody.gravityScale>=-0.1)
        {
            moveDir.y = Input.GetAxis("Vertical");
            moveDir = moveDir.normalized;
            playerRigidbody.velocity = moveDir * speedForMove;
        }
        //dash
        if (Input.GetKeyDown(KeyCode.E))
        {
            v = playerRigidbody.velocity.x * speedForDash;
            Vector2 vector2=new Vector2(v,0);
            playerRigidbody.AddForce(vector2, ForceMode2D.Impulse);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0);
        Vector3 vector3temp = new Vector3(transform.position.x - line , transform.position.y - line);
        Gizmos.DrawLine(transform.position,vector3temp);
    }
}
