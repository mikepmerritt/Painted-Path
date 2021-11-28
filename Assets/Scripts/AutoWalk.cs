using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoWalk : MonoBehaviour
{
    public bool StopOnEdges;
    public float WalkSpeed;
    public float BaseSpeed;
    public bool OnGround;
    public int Direction;

    void Start()
    {
        OnGround = false;
        Direction = 1; // start facing right
    }

    void Update()
    {
        if(Direction == -1)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (Direction == 1)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(WalkSpeed, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Walkable"))
        {
            // make the player start walking
            WalkSpeed = BaseSpeed * Direction;

            // set the player as on the ground
            if (OnGround == false)
            {
                OnGround = true;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        OnGround = false;
        WalkSpeed = 0;
    }
}
