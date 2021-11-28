using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawPath : MonoBehaviour
{
    public GameObject PathPrefab;

    private void FixedUpdate()
    {
        if(Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(PathPrefab, mousePosition + new Vector3(0, 0, 10), Quaternion.identity);
        }
    }
}
