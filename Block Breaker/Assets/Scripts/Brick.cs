using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Brick : MonoBehaviour
{
    public Sprite[] hitSprites;

    private int timesHit;
    private LevelManager levelManager;

	// Use this for initialization
	void Start ()
    {
        timesHit = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        bool isBreakable = (this.tag == "breakable");
        if (isBreakable)
        {
            HandleHits();
        }
    }

    void HandleHits()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;

        if (timesHit >= maxHits)
        {
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }
    }
    void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex])
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }

    // TODO Remove This Method once we can actually win!
    void SimulateWin()
    {
        levelManager.LoadNextLevel();
    }
}
