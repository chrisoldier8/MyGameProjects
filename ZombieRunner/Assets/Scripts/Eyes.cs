using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour {

    public float speed = 5f;
    
    private Camera eyes;
    private float defaultFOV = 60f;
    

	// Use this for initialization
	void Start () {
        eyes = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Zoom"))
        {
            eyes.fieldOfView = Mathf.Lerp(defaultFOV, defaultFOV - defaultFOV * 0.5f, speed * Time.deltaTime);
        }
        else
        {
            eyes.fieldOfView = Mathf.Lerp(defaultFOV - defaultFOV * 0.5f, defaultFOV, speed * Time.deltaTime);
        }

	}
}
