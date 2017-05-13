using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class Brick : MonoBehaviour { 
    private LevelManager levelManager;
    private int maxHits;
    private int hits;
    private bool isBreakable;
    private AudioClip crackSound;
    private AudioSource sound;
    public Sprite[] sprites;
    public static int totalBricks = 0;
    public GameObject smoke;

    // Use this for initialization
    void Start () {
        isBreakable = (this.tag == "Breakable");
        maxHits = sprites.Length + 1;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        hits = 0;
        sound = gameObject.GetComponent<AudioSource>();
        crackSound = Resources.Load<AudioClip>("Sounds/crack");
        
        if (isBreakable) totalBricks++;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnCollisionExit2D (Collision2D collision) {
        if (collision.gameObject.GetComponent<Ball>()) {
            sound.Play();
        } else {
            print(collision.gameObject.GetType());
        }

        if (isBreakable) {
            HandleHits();
        }
    }

    void HandleHits() {
        hits++;
        if (hits >= maxHits) {
            AudioSource.PlayClipAtPoint(crackSound, transform.position);
            totalBricks--;
            levelManager.BrickDestroyed();
            GameObject smokePuff = (GameObject)Instantiate(smoke, gameObject.transform.position, Quaternion.identity);
            smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;

            Destroy(gameObject);
        } else {
            LoadNextSprite();
        }
    }

    private void LoadNextSprite() {
        int spriteIndex = hits - 1;
        if (sprites[spriteIndex]) {
            this.GetComponent<SpriteRenderer>().sprite = sprites[spriteIndex];
        } else {
            Debug.LogError("Brick Sprite " + spriteIndex + " Missing");
        }
    }
}
