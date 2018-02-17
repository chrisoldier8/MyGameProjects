using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBehaviour : MonoBehaviour {

    public float health = 150;

    public float maxHealth = 200;

    public GameObject projectile;
    public float projectileSpeed;
    public float firingRate = 1;
    public float shotsPerSecond = 0.5f;

    public int scoreValue = 150;

    public AudioClip EnemyShoots;
    public AudioClip EnemyHit;

    private ScoreKeeper scoreKeeper;

    private Image healthBar;

    private void Start()
    {
        InitializeHealthBars();
        scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision);
        Projectile missile = collision.gameObject.GetComponent<Projectile>();
        if (missile)
        {
            health -= missile.GetDamage();
            missile.Hit();
            healthBar.fillAmount = health / maxHealth;
            if (health <= 0)
            {
                Die();
            }
        }
    }

    public void InitializeHealthBars()
    {
        healthBar = transform.Find("HealthBG").Find("Health").GetComponent<Image>();
    }

    void Die()
    {
        Destroy(gameObject);
        scoreKeeper.Score(scoreValue);
        AudioSource.PlayClipAtPoint(EnemyHit, transform.position);
    }
    
    void Update()
    {
        float probability = shotsPerSecond * Time.deltaTime;
        if(Random.value < probability)
        {
            EnemyFire();
        }
        
        
    }

    void EnemyFire()
    {
        GameObject missile = (GameObject)Instantiate(projectile, transform.position, Quaternion.identity);
        missile.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -projectileSpeed, 0);
        AudioSource.PlayClipAtPoint(EnemyShoots, transform.position);

    }
}
