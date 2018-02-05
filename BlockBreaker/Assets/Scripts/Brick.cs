using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Brick : MonoBehaviour {

    public static int breakableCount = 0;

    private int timesHit;
    private LevelManager LevelManager;
    private bool isBreakable;

    public Sprite[] hitSprites;
    public AudioClip crack;

	// Use this for initialization
	void Start () {
        isBreakable = (this.tag == "Breakable");
        //Keep track of breakable bricks
        if(isBreakable){
            breakableCount++;
        }
        LevelManager = GameObject.FindObjectOfType<LevelManager>();
        timesHit = 0;
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(crack, transform.position);
        if (isBreakable)
        {
            handleHits();
        }
        
        
    }

    void handleHits()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;

        if (timesHit >= maxHits)
        {
            breakableCount--;
            print(breakableCount);
            LevelManager.brickDestroyed();
            Destroy(gameObject);
        }
        else
        {
            loadSprites();
        }
    }

    //TODO Remove this method once we can actually win!
    void SimulateWin()
    {
        LevelManager.loadNextLevel();
    }

    void loadSprites()
    {
        int spriteIndex = timesHit-1;

        if (hitSprites[spriteIndex])
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        
    }
}
