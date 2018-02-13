using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public float speed = 10f;
    public float padding = 0.2f;

    public GameObject projectile;
    public float projectileSpeed;

    public float firingRate = 0.2f;
    public float health = 500;

    public AudioClip PlayerShoots;

    float xmin;
    float xmax;

	// Use this for initialization
	void Start () {
        InitializeScreen();
    }

    // Update is called once per frame
    void Update()
    {
        MoveWithKeys();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            InvokeRepeating("FireLaser", 0.0000001f, firingRate);

        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke("FireLaser");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        Projectile missile = collision.gameObject.GetComponent<Projectile>();
        if (missile)
        {
            Debug.Log("Player collided with a missile");
            health -= missile.GetDamage();
            missile.Hit();
            if (health <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        LevelManager man = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        man.LoadLevel("Win Screen");
        Destroy(gameObject);
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


    public void FireLaser()
    {
        GameObject laser = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed, 0);
        AudioSource.PlayClipAtPoint(PlayerShoots, transform.position);
    }
}
