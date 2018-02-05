using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name)
    {
        Debug.Log("Level load requested for: " + name);
        SceneManager.LoadScene(name);
        Brick.breakableCount = 0;
    }

    public void QuitRequest()
    {
        Debug.Log("I want to quit!");
        Application.Quit();
    }

    public void loadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);

    }

    public void brickDestroyed()
    {
        if (Brick.breakableCount <= 0)
        {
            loadNextLevel();
        }
    }
}
