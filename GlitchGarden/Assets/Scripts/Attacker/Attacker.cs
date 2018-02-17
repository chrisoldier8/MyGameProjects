using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
public class Attacker : MonoBehaviour {

    [Range (-1f, 1.5f)]
    public float currentSpeed;
    public float currentDamage;

    private GameObject currentTarget;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);

        if (!currentTarget)
        {
            anim.SetBool("isAttacking", false);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(name + " trigger enter");
        
    }

    public void SetSpeed(float speed)
    {
        currentSpeed = speed;
    }

    // Called from the animator at time of actual attack
    public void StrikeCurrentTarget(float damage)
    {
        currentDamage = damage;

        if (currentTarget)
        {
            Health enemyHealth = currentTarget.GetComponent<Health>();
            if (enemyHealth)
            {
                Debug.Log(name + " " + currentDamage + " Damage dealt!");
                enemyHealth.LoseHealth(damage);
            }
        }
    }

    public void Attack(GameObject obj)
    {
        currentTarget = obj;
    }
}
