using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private Paddle paddle;
    private bool hasStarted = false;

    private Vector3 paddleToBallVector;

	// Use this for initialization
	void Start () {
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;
        print(paddleToBallVector.y);
        
	}
	
	// Update is called once per frame
	void Update () {

        if (!hasStarted)
        {
            //Lock the ball relative to the paddle
            this.transform.position = paddle.transform.position + paddleToBallVector;

            //Wait for a MouseClick to launch the ball
            if (Input.GetMouseButtonDown(0))
            {
                print("Mouse clicked, launch ball");

                this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
                hasStarted = true;

            }
        }
        
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 tweak = new Vector2(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f));
        print(tweak);
        if (hasStarted)
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            GetComponent<Rigidbody2D>().velocity += tweak;
        }
        
    }

}
