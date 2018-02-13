using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

    public static int score = 0;
    Text scoreText;

	// Use this for initialization
	void Start () {
        scoreText = GetComponent<Text>();
        Reset();
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
