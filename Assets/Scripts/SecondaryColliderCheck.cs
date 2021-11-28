using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class serves as a trigger checker for the floor checks and wall checks for grounded enemies and the artist.
public class SecondaryColliderCheck : MonoBehaviour
{
    public bool CheckForHit; // determines whether this trigger checks to see if there is a collision when true or a lack of a collision when false.

    // check inside the trigger, and flip the player if the trigger is inside a walkable surface (a wall for example)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (CheckForHit)
        {
            if (collision.gameObject.CompareTag("Walkable"))
            {
                GetComponentInParent<AutoWalk>().Direction *= -1;
                GetComponentInParent<AutoWalk>().WalkSpeed = GetComponentInParent<AutoWalk>().BaseSpeed * GetComponentInParent<AutoWalk>().Direction;
            }
        }
    }

    // check inside the trigger, and flip the player if the trigger is no longer in a walkable surface (over a cliff for example)
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!CheckForHit)
        {
            if (collision.gameObject.CompareTag("Walkable"))
            {
                GetComponentInParent<AutoWalk>().Direction *= -1;
                GetComponentInParent<AutoWalk>().WalkSpeed = GetComponentInParent<AutoWalk>().BaseSpeed * GetComponentInParent<AutoWalk>().Direction;
            }
        }
    }
}
