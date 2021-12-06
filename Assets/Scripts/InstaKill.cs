using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstaKill : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Game over, restart");
            Destroy(collision.gameObject);
            DrawPath.CurrentPathCount = 0;
        }
    }
}
