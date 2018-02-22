using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

    public static int score = 0;
    Text scoreText;

    private void Awake()
    {
        //DontDestroyOnLoad(gameObject);
        print("Dont Destroy on Load ScoreKeeper");
    }

    // Use this for initialization
    void Start () {
        scoreText = GetComponent<Text>();
        //Reset();
        //print("Score reset Scorekeeper");
	}
	
	// Update is called once per frame
	void Update () {
     
	}

    public void Score(int points)
    {
        score += points;
        scoreText.text = score.ToString();
    }

    public static void Reset()
    {
        score = 0;
    }
}
