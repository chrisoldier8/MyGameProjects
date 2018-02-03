using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NumberWizard : MonoBehaviour {

    // Use this for initialization
    int max;
    int min;
    int guess;

    public int maxGuessesAllowed = 5;

    public Text text;

    void Start () {
        startGame();
    }

    void startGame()
    {
        max = 1000;
        min = 1;
        nextGuess();


    }

    
    public void GuessHigher()
    {
        min = guess;
        nextGuess();
    }

    public void GuessLower()
    {
        max = guess;
        nextGuess();
    }

    void nextGuess()
    {
        guess = UnityEngine.Random.Range(min, max+1);
        text.text = guess.ToString();
        maxGuessesAllowed -= 1;

        if (maxGuessesAllowed <= 0)
        {
            SceneManager.LoadScene("Win");
        }
    }

}
