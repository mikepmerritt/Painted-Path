using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoWalk : MonoBehaviour
{
    public bool StopOnEdges;
    float WalkSpeed;
    float SpeedNumber;
    private Rigidbody2D rb;
    bool OnGround;
    int direction;
    

    void Start()
    {
        WalkSpeed = 2;
        SpeedNumber = WalkSpeed;
        OnGround = false;
        direction = 1;

    }

    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(SpeedNumber * direction, 0);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SpeedNumber = 2;
        if (OnGround == false)
        {
            OnGround = true;
        }
        else
        {
            direction = -1 * direction;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        OnGround = false;
        SpeedNumber = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        direction = -1 * direction;
    }
}
