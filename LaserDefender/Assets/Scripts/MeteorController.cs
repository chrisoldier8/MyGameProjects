using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteors : MonoBehaviour
{

    public float health;

    public GameObject meteor;

    public int speed = 5;

    public int scoreValue = 200;

    private ScoreKeeper scoreKeeper;

    // Use this for initialization
    void Start()
    {
        scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();

        InvokeRepeating("spawnMeteor", 5f, 3f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Projectile missile = collision.gameObject.GetComponent<Projectile>();
        if (missile)
        {
            health -= missile.GetDamage();
            missile.Hit();
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    void spawnMeteor()
    {
        GameObject met = (GameObject)Instantiate(meteor, transform.position, Quaternion.identity);
        met.GetComponent<Rigidbody2D>().velocity = Vector3.down * speed * Time.deltaTime;
    }
}
