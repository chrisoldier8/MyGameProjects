using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorController : MonoBehaviour
{

   

    public GameObject meteor;

    public int speed = 10;

    public int scoreValue = 200;

    

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("spawnMeteor", 2f, 5f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void spawnMeteor()
    {
        float randomSize = Random.Range(0.3f, 1.2f);
        // Assign random position to Meteor
        GameObject randMeteor = (GameObject)Instantiate(meteor, transform.position, Quaternion.identity);
        randMeteor.transform.parent = transform;
        randMeteor.transform.position = new Vector3(Random.Range(-7f, 7f), 5.5f, 0f);
        randMeteor.GetComponent<Transform>().localScale = new Vector3(randomSize, randomSize, 0f);
        

        randMeteor.GetComponent<Rigidbody2D>().velocity = Vector3.down * speed * Time.deltaTime;
        
    }
}
