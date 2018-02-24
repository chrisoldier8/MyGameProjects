using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start () {
        Text myText = GetComponent<Text>();
        myText.text = ScoreKeeper.score.ToString();
        //myText.text = ScoreKeeper.score.ToString();
        ScoreKeeper.Reset();
        print("Score reset ScoreDisplay");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
