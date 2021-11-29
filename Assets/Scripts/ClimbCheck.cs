using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbCheck : MonoBehaviour
{
    // if the player is hitting a sloped path, give them some vertical mobility
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Walkable") || collision.gameObject.CompareTag("Path"))
        {
            GetComponentInParent<AutoWalk>().ClimbSpeed = 1f;
        }
    }
}
