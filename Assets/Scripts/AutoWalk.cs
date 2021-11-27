using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoWalk : MonoBehaviour
{
    public bool StopOnEdges;
    float WalkSpeed;
    private Rigidbody2D rb;
    bool OnGround;
    

    void Start()
    {
        WalkSpeed = 2;
        OnGround = false;
        

    }

    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(WalkSpeed, 0);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(OnGround == false)
        {
            WalkSpeed = 2;
            OnGround = true;
        }
        else
        {
            WalkSpeed = -2;
            OnGround = true;
        }
        //WalkSpeed = 2;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        OnGround = false;
        WalkSpeed = 0;
    }
}
