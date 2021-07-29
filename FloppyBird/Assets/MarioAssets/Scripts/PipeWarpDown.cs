using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeWarpDown : MonoBehaviour {
	private LevelManager t_LevelManager;
	private Mario mario;
	private Transform stop;
	private bool isMoving;

	private float platformVelocityY = -0.05f;
	public string sceneName;
	public bool leadToSameLevel = true;

    public GameObject gameManager;

	// Use this for initialization
	void Start () {
		t_LevelManager = FindObjectOfType<LevelManager> ();
		mario = FindObjectOfType<Mario> ();
		stop = transform.parent.transform.Find ("Platform Stop");
	}

	void FixedUpdate() {
		if (isMoving) {
			if (transform.position.y > stop.position.y) {
				if (!t_LevelManager.timerPaused) {
					t_LevelManager.timerPaused = true;
				}
				transform.position = new Vector2 (transform.position.x, transform.position.y + platformVelocityY);
			} else {
				if (leadToSameLevel) {
					t_LevelManager.LoadSceneCurrentLevel (sceneName);
				} else {
					t_LevelManager.LoadNewLevel (sceneName);
				}
			}
		}
	}

	bool marioEntered = false;
	void OnTriggerStay2D(Collider2D other) {
		if (other.tag == "Player" && mario.isCrouching && !marioEntered) {

            //Debug.Log("HERE 1: " + gameManager.GetComponent<GameStateManager>().GetCoins());
            LevelManager t_LevelManager = FindObjectOfType<LevelManager>();
            ScoreScript.SetScore(t_LevelManager.coins);

            /*
            Debug.Log("HERE 1: " + Difficulty.totalCoins);
            Difficulty.totalCoins = gameManager.GetComponent<GameStateManager>().GetCoins();
            Debug.Log("HERE 2: " + Difficulty.totalCoins);

            ScoreScript.SetScore();
            */

            mario.AutomaticCrouch ();
			isMoving = true;
			marioEntered = true;
			t_LevelManager.musicSource.Stop ();
			t_LevelManager.soundSource.PlayOneShot (t_LevelManager.pipePowerdownSound);
		}
	}
}
