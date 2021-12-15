using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public int LevelToLoad;

    public void LoadNewScene()
    {
        SceneManager.LoadScene(LevelToLoad);
        DrawPath.CurrentPathCount = 0;
    }
}
