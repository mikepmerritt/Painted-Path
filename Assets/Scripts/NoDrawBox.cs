using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoDrawBox : MonoBehaviour
{
    public float minX, maxX, minY, maxY;
    void Start()
    {
        minX = transform.position.x - transform.localScale.x / 2f;
        maxX = transform.position.x + transform.localScale.x / 2f;
        minY = transform.position.y - transform.localScale.y / 2f;
        maxY = transform.position.y + transform.localScale.y / 2f;
    }
}
