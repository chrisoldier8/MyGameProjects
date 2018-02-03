using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour {

    // Use this for initialization
    int max;
    int min;
    int guess;

    void Start () {
        startGame();
    }

    void startGame()
    {
        max = 1000;
        min = 1;
        guess = 500;

        max += 1;

        print("==========================");
        print("Welcome to NumberWizard");
        print("Pick a number in your head, but don't tell me!");



        print("The highest number you can pick is " + max);
        print("The lowest number you can pick is " + min);

        print("Is the number higher or lower than " + guess + "?");
        print("Up arrow for higher, Down arrow for lower, Return for equals");

    }

    
    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            min = guess;
            nextGuess();
        }

        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            max = guess;
            nextGuess();
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            print("I Won");
            startGame();
        }


    }

    void nextGuess()
    {
        guess = (max + min) / 2;
        print("Higher or lower than " + guess);
        print("Up arrow for higher, Down arrow for lower, Return for equals");
    }

}
