using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelClear : MonoBehaviour
{
    public int nextlevelnum;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Level cleared!");
            SceneManager.LoadScene(nextlevelnum);
            DrawPath.CurrentPathCount = 0;
        }
    }
}
