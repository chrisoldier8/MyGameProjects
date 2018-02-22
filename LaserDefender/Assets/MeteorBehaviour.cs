using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorBehaviour : MonoBehaviour {

    public float health;
    public int scoreValue = 25;

    private ScoreKeeper scoreKeeper;

    // Use this for initialization
    void Start () {
        scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();

    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Projectile missile = collision.gameObject.GetComponent<Projectile>();
        //Debug.Log(collision + " collided with meteor");
        if (missile)
        {
            health -= missile.GetDamage();
            missile.Hit();
            if (health <= 0)
            {
                scoreKeeper.Score(scoreValue);
                Destroy(gameObject);
            }
        }
    }
}
