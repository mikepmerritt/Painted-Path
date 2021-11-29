using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoWalk : MonoBehaviour
{
    public bool StopOnEdges;
    public float WalkSpeed, ClimbSpeed;
    public float BaseSpeed;
    public bool OnGround;
    public int Direction;
    public float OffGroundTimer;
    public GameObject EmergencyFloorChecker;

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

        if (OffGroundTimer > 0 && !OnGround)
        {
            OffGroundTimer -= Time.deltaTime;
        }
        else if (OffGroundTimer <= 0 && !OnGround)
        {
            WalkSpeed = 0;
            ClimbSpeed = 0;
            EmergencyFloorChecker.SetActive(true);
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(WalkSpeed, ClimbSpeed);

        // if the moving entity has fallen off the bottom of the screen, kill it
        if(transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Walkable"))
        {
            // make the player start walking
            WalkSpeed = BaseSpeed * Direction;
            ClimbSpeed = 0;

            // set the player as on the ground
            OnGround = true;
        }

        if(collision.gameObject.CompareTag("Path"))
        {
            // make the player start walking
            WalkSpeed = BaseSpeed * Direction;

            // set the player as on the ground
            OnGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        OnGround = false;
        OffGroundTimer = 0.4f;
    }
}
