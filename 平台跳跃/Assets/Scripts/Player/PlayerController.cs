using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Move
{
    //status
    public bool onground = true;
    public bool onhook = false;
    public bool onwall = false;
    public int status = 0;
    //idle=0,run_right=1,jump_right=2,fall=3,dash=4,climb=5,grb=6,dying=7,dead=-1;

    Rigidbody2D playerRigidbody;
    Collider2D playerCollider;

    Vector2 moveDir;
    public float speedForMove = 80;
    public float speedForJumpHorizontal = 40;
    public float speedForJumpVertical = 20;
    public float speedForDash = 80;
    public float line = 0.3f;
    public float g = 20;
    public float dragToTheWall = 50;
    [Range(-5, 5)]
    public float v;
    //hook
    public float roleLength;
    private GameObject nearestHook;
    private float nearestDistance;
    private Vector2 velocityBeforHook;


    private void Start()
    {
        playerCollider = GetComponent<Collider2D>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        //transform.SetPositionAndRotation(new Vector3(4, 0, transform.position.z), Quaternion.identity);

    }
    void Update()
    {
        onground = Physics2D.Raycast(transform.position, Vector2.down, 1f, 1 << LayerMask.NameToLayer("ground"));
        //move&jump
        moveDir.x = Input.GetAxis("Horizontal");
        //moveDir.y = Input.GetAxis("Jump");
        moveDir = moveDir.normalized;

        //move
        if (moveDir.y>=-0.01&&moveDir.y<=0.01)
        {
            playerRigidbody.velocity = new Vector2(moveDir.x * speedForMove, playerRigidbody.velocity.y);
        }
        //jump
        //为什么在墙上不能跳啊
        if (Input.GetKeyDown(KeyCode.Space)&&(onground))
        {
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, 0);
            Vector2 vector2 = new Vector2(moveDir.x * speedForJumpVertical, speedForJumpHorizontal);
            // Debug.Log(vector2);
            playerRigidbody.AddForce(vector2, ForceMode2D.Impulse);
        }

        //hold
        if (Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y+0.3f, transform.position.z), Vector2.right, line, 1 << LayerMask.NameToLayer("wall"))|| Physics2D.Raycast(transform.position, Vector2.left, line, 1 << LayerMask.NameToLayer("wall")))
        {
            if (Input.GetKey(KeyCode.Q))
            {
                onwall = true;
                playerRigidbody.gravityScale = 0;
                if (Physics2D.Raycast(transform.position, Vector2.right, 0.3f, 1 << LayerMask.NameToLayer("wall")))
                {
                    Debug.Log("1");
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(dragToTheWall, 0), ForceMode2D.Impulse);

                }
                else if(Physics2D.Raycast(transform.position, Vector2.left, 0.3f, 1 << LayerMask.NameToLayer("wall")))
                {
                    Debug.Log("2");
                    transform.rotation = Quaternion.Euler(0, -180, 0);
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(-dragToTheWall, 0),ForceMode2D.Impulse);
                }
            }
            if (Input.GetKeyUp(KeyCode.Q))
            {
                onwall = false;
                playerRigidbody.gravityScale = g;
            }
        }
        else
        {
            onwall = false;
            playerRigidbody.gravityScale = g;
        }
        
        //climb
        if (onwall)
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

        //hook
        if (Input.GetKey(KeyCode.L))
        {
            if ((!onwall)&&(!onwall)&&(!onhook))
            {
                Collider2D[] collider2s = Physics2D.OverlapCircleAll(transform.position, roleLength, 1 << LayerMask.NameToLayer("hook"));
                if (collider2s.Length!=0)
                {
                    Debug.Log("2");
                    onhook = true;
                    nearestDistance = roleLength+1;
                    foreach (var item in collider2s)
                    {
                        float distance = Vector2.Distance(transform.position, item.gameObject.transform.position);
                        if (distance<nearestDistance)
                        {
                            nearestDistance = distance;
                            nearestHook = item.gameObject;
                        }
                    }
                    velocityBeforHook = playerRigidbody.velocity;
                    nearestHook.GetComponent<HingeJoint2D>().connectedBody = playerRigidbody;
                }
            }
        }
        //onhook时unlock rotation
        if (onhook)
        {
            GetComponent<Transform>().up = nearestHook.GetComponent<Transform>().position - transform.position;
        }
        //改变方向
        if (!onwall)
        {
            ChangeDirection(1);
        }
        //status
        //idle=0,run_right=1,jump_right=2,fall_right=3,dash_right=4,climb_right=5,grb=6
        if (GetComponent<PlayerStatus>().blood==0)
        {
            if (status!=-1&&status!=7)
            {
                status = 7;
            }
            else
            {
                status = -1;
            }
            
        }
        else if (onground)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                status = 4;
            }
            else if (moveDir.x <= -0.01 || moveDir.x >= 0.01)
            {
                status = 1;
            }
            else
            {
                status = 0;
            }
        }
        else if (onwall)
        {
            if (GetComponent<Rigidbody2D>().velocity.y>1|| GetComponent<Rigidbody2D>().velocity.y<-1)
            {
                status = 5;
            }
            else
            {
                status = 6;
            }
        }
        else
        {
            if (GetComponent<Rigidbody2D>().velocity.y<0)
            {
                status = 3;
            }
            else
            {
                status = 2;
            }
        }
        GetComponent<Animator>().SetInteger("status", status);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0);
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x - line, transform.position.y, 0));
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + line, transform.position.y, 0));
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y + line, 0));
    }
}
