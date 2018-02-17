using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//check if Attacker component is attached, if not, add
[RequireComponent (typeof (Attacker))]
public class Fox : MonoBehaviour {

    private Attacker attacker;
    private Animator animator;

	// Use this for initialization
	void Start () {
        attacker = GetComponent<Attacker>();
        animator = GetComponent<Animator>();
        //animator.
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        GameObject obj = collision.gameObject;

        //abort method if not colliding
        if (!obj.GetComponent<Defender>())
        {
            return;
        }

        if (obj.GetComponent<Stone>())
        {
            animator.SetTrigger("jumpTrigger");
        }
        else
        {
            animator.SetBool("isAttacking", true);
            attacker.Attack(obj);
        }

        Debug.Log(name + " collided with " + collision);

        //attacker.StrikeCurrentTarget(20);
        
    }
}
