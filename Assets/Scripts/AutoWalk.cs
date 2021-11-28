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
        SpeedNumber = 2;
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
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        OnGround = false;
        SpeedNumber = 0;
    }
}
