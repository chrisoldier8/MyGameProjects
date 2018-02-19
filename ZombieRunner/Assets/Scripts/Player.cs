using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Transform PlayerSpawnPoints;
    public bool respawn = false;

    private Transform[] spawnPoints;
    private bool lastToggle = false;

    // Use this for initialization
    void Start () {
        spawnPoints = PlayerSpawnPoints.GetComponentsInChildren<Transform>();
        foreach (Transform position in spawnPoints)
        {
            print(position.transform.position);
        }
        //ReSpawn();
	}
	
	// Update is called once per frame
	void Update () {
        if (lastToggle != respawn)
        {
            ReSpawn();
            respawn = false;
        }
        else
        {
            lastToggle = respawn;
        }
	}

    private void ReSpawn()
    {
        int randPos = Random.Range(1, spawnPoints.Length);
        transform.position = spawnPoints[randPos].transform.position;
    }
}
