using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public AudioClip PlayerShoots;

    public float speed = 10f;
    public float padding = 0.2f;

    public GameObject projectile;
    public float projectileSpeed;

    public float firingRate = 0.2f;
    public float health = 500;
    public float maxHealth = 500;

    private Image healthBar;
    private LevelManager levelManager;

    Text currentHealthText;
    Text maxHealthText;

    float xmin;
    float xmax;

    float ymin;
    float ymax;

	// Use this for initialization
	void Start () {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        InitializeHealthBars();
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

    public void InitializeHealthBars()
    {
        maxHealthText = GameObject.Find("maxHealth").GetComponent<Text>();
        currentHealthText = GameObject.Find("currentHealth").GetComponent<Text>();
        currentHealthText.text = maxHealth.ToString();
        healthBar = transform.Find("HealthBG").Find("Health").GetComponent<Image>();
        maxHealthText.text = maxHealth.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        Projectile missile = collision.gameObject.GetComponent<Projectile>();
        if (missile)
        {
            //Debug.Log("Player collided with a missile");
            health -= missile.GetDamage();
            missile.Hit();
            healthBar.fillAmount = health / maxHealth;
            currentHealthText.text = health.ToString();
            if (health <= 0)
            {
                Die();
                levelManager.LoadLevel("Win Screen");
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
        //MOVE LEFT   
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        //MOVE RIGHT
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        //MOVE UP
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        //MOVE DOWN
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
        //MOVE LEFT AND UP
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime/4;
            transform.position += Vector3.up * speed * Time.deltaTime/2;
        }
        //MOVE LEFT AND DOWN
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime / 4;
            transform.position += Vector3.down * speed * Time.deltaTime / 2;
        }
        //MOVE RIGHT AND UP
        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime / 4;
            transform.position += Vector3.up * speed * Time.deltaTime / 2;
        }
        //MOVE RIGHT AND DOWN
        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime / 4;
            transform.position += Vector3.down * speed * Time.deltaTime / 2;
        }

        float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
        float newY = Mathf.Clamp(transform.position.y, ymin, ymax);

        transform.position = new Vector3(newX, newY, transform.position.y);
    }

    void InitializeScreen()
    {
        float distance = transform.position.z - Camera.main.transform.position.z;

        Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        Vector3 upMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, distance));
        Vector3 downMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));

        print(upMost.y);
        print(downMost.y);

        xmin = leftMost.x + padding;
        xmax = rightMost.x - padding;
        ymin = downMost.y - padding + 1;
        ymax = upMost.y - padding;
    }


    public void FireLaser()
    {
        GameObject laser = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed, 0);
        AudioSource.PlayClipAtPoint(PlayerShoots, transform.position);
    }
}
