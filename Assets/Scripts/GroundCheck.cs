using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    // check inside the trigger, and flip the player if the trigger is inside a walkable surface (a wall for example)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Walkable") || collision.gameObject.CompareTag("Path"))
        {
            GetComponentInParent<AutoWalk>().ClimbSpeed = 1f;
        }
    }
}
