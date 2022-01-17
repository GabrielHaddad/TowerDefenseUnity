using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public void LoadLevel1()
    {
        LoadLevel("Level1");
    }

    public void LoadLevel2()
    {
        LoadLevel("Level2");
    }

    public void LoadLevel3()
    {
        LoadLevel("Level3");
    }

    void LoadLevel(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
