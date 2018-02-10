using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 10f;
    public float padding = 0.2f;

    float xmin;
    float xmax;

	// Use this for initialization
	void Start () {
        InitializeScreen();
    }
	
	// Update is called once per frame
	void Update () {
        MoveWithKeys();
    }


    void MoveWithKeys()
    {
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
            //shorter Version
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        float newX = Mathf.Clamp(transform.position.x, xmin, xmax);

        transform.position = new Vector3(newX, transform.position.y, transform.position.y);
    }

    void InitializeScreen()
    {
        float distance = transform.position.z - Camera.main.transform.position.z;

        Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));

        xmin = leftMost.x + padding;
        xmax = rightMost.x - padding;
    }
}
