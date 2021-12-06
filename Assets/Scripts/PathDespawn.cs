using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathDespawn : MonoBehaviour
{
    public float Lifespan;

    private void Update()
    {
        Lifespan -= Time.deltaTime;
        if (Lifespan <= 0)
        {
            DrawPath.CurrentPathCount--;
            Destroy(gameObject);
        }
    }
}
