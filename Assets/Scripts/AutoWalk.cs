using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoWalk : MonoBehaviour
{
    public bool StopOnEdges;
    float WalkSpeed;
    private Rigidbody2D rb;
    

    void Start()
    {
        WalkSpeed = 2;

        

    }

    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(WalkSpeed, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        WalkSpeed = 2;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        WalkSpeed = 0;
    }
}
