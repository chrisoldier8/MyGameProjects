using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public float autoLoadNextLevelAfter;

    private void Start()
    {
        int currLevel = SceneManager.GetActiveScene().buildIndex;
        if (currLevel == 0)
        {
            Invoke("LoadNextLevel", autoLoadNextLevelAfter);
        }
        else if (autoLoadNextLevelAfter < 0)
        {
            Debug.LogError("Use a positive number in secounds!");
        }
        
    }

    public void LoadLevel(string name){
		Debug.Log ("New Level load: " + name);
		SceneManager.LoadScene(name);
	}

	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public int countLevels()
    {
        return SceneManager.sceneCountInBuildSettings;
    }
}
