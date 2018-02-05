using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LooseCollider : MonoBehaviour {

    private LevelManager levelManager;

    private void OnTriggerEnter2D(Collider2D trigger)
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        print("Trigger");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("Collision");
        SceneManager.LoadScene("Lose");
        

    }
}
