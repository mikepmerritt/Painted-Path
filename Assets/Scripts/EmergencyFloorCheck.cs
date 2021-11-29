using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmergencyFloorCheck : MonoBehaviour
{
    // check inside the trigger, and put the player on the floor and moving if successful
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Walkable") || other.gameObject.CompareTag("Path"))
        {
            GetComponentInParent<AutoWalk>().OnGround = true;
            GetComponentInParent<AutoWalk>().WalkSpeed = GetComponentInParent<AutoWalk>().BaseSpeed * GetComponentInParent<AutoWalk>().Direction;
            gameObject.SetActive(false);
        }
    }
}
