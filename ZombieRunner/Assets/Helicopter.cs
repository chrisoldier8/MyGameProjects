using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour {

    private bool called = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("CallHeli"))
        {
            called = true;
        }
        else
        {
            eyes.fieldOfView = Mathf.Lerp(defaultFOV - defaultFOV * 0.5f, defaultFOV, speed * Time.deltaTime);
        }
    }
}
