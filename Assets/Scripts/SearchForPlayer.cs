using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SearchForPlayer : MonoBehaviour
{
    public int levelnum;
    
    void Update()
    {
        if(GameObject.FindGameObjectsWithTag("Player").Length == 0)
        {
            SceneManager.LoadScene(levelnum);
        }
    }
}
