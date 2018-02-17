using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public float health = 100f;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoseHealth(float damage)
    {
        if (health > 0)
        {
            health -= damage;
        }

        else
        {
            Debug.Log(name + " died!");
            Die();
            //Optionally trigger animation
        }
        
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
