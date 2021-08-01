using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Castle : MonoBehaviour {
	private LevelManager t_LevelManager;
	private Transform flag;
	private Transform flagStop;
	private bool moveFlag;

	private float flagVelocityY = 0.025f;
	public string sceneName;

	// Use this for initialization
	void Start () {
		t_LevelManager = FindObjectOfType<LevelManager> ();
		flag = transform.Find ("Flag");
		flagStop = transform.Find ("Flag Stop");
	}

	void FixedUpdate() {
		if (moveFlag) {
			if (flag.position.y < flagStop.position.y) {
				flag.position = new Vector2 (flag.position.x, flag.position.y + flagVelocityY);
			} else {
				// t_LevelManager.LoadNewLevel (sceneName, t_LevelManager.levelCompleteMusic.length);
				Debug.Log("Score is this");
				Debug.Log(t_LevelManager.coins);
				ScoreScript.SetScore(t_LevelManager.coins);
				Debug.Log(ScoreScript.GetScore());
				SceneManager.LoadScene(sceneName);
			}
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Player") {
			moveFlag = true;
			// t_LevelManager.MarioCompleteLevel ();
		}
	}
}
