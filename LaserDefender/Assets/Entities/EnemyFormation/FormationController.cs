using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FormationController : MonoBehaviour
{

    public GameObject enemyPrefab;
    public GameObject enemyPrefab2;
    
    public float width = 15f;
    public float height = 8f;
    public float speed = 5f;
    public float spawnDelay = 0.5f;

    private bool movingRight = false;
    private float xmin;
    private float xmax;

    private LevelManager levelManager;




    // Use this for initialization
    void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();

        float distanceToCamera = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftBoundary = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceToCamera));
        Vector3 rightBoundary = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distanceToCamera));
        xmax = rightBoundary.x;
        xmin = leftBoundary.x;

        SpawnUntilFull();
       
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
    }

    // Update is called once per frame
    void Update()
    {
        if (movingRight)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        float rightEdgeOfFormation = transform.position.x + (0.5f * width);
        float leftEdgeOfFormation = transform.position.x - (0.5f * width);
        if (leftEdgeOfFormation < xmin)
        {
            movingRight = true;
        }
        else if (rightEdgeOfFormation > xmax)
        {
            movingRight = false;
        }

        //If all enemies are dead, spawn new Enemies

        //if (AllMembersDead())
        //{
        //    Debug.Log("Empty Formation");
        //    SpawnUntilFull();
        //}

        //If all ships are Dead go to the next Scene in the index --> new Level or End Screen

        if (AllMembersDead())
        {
            levelManager.loadNextLevel();
        }


    }

    void SpawnUntilFull()
    {
        Transform freePosition = NextFreePosition();

        int positionCount;
        positionCount = transform.childCount;

        
        if (freePosition)
        {
            GameObject enemy = Instantiate(enemyPrefab, freePosition.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = freePosition;
        }

        else if (freePosition)
        {
            GameObject enemy = Instantiate(enemyPrefab2, freePosition.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = freePosition;
        }
        

        

        if (NextFreePosition())
        {

            Invoke("SpawnUntilFull", spawnDelay);
        }
        
    }

    void spawnEnemies()
    {
        foreach (Transform child in transform)
        {
            GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = child;
        }
    }

    Transform NextFreePosition()
    {
        //iterates through every "Position" and check if there is an empty position
        foreach(Transform childPositionGameObject in transform)
        {
            if (childPositionGameObject.childCount == 0)
            {
                return childPositionGameObject;
            }
        }
        return null;
    }

    bool AllMembersDead()
    {
        foreach (Transform childPositionGameObject in transform)
        {
            if (childPositionGameObject.childCount > 0)
            {
                return false;
            }
        }

        return true;
    }

}

    
