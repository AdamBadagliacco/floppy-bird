using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;


public class GameOverScreen : MonoBehaviour {
	private GameStateManager t_GameStateManager;

	public Text WorldTextHUD;
	public Text ScoreTextHUD;
	public Text CoinTextHUD;
	public Text MessageText;

	public AudioSource gameOverMusicSource;


	// Use this for initialization
	void Start () {
		Time.timeScale = 1;

		MessageText.text = MessageText.text.Replace("?", ScoreScript.GetScore().ToString());


		gameOverMusicSource.volume = PlayerPrefs.GetFloat ("musicVolume");
		gameOverMusicSource.Play();
	}

	IEnumerator LoadSceneDelayCo(string sceneName, float delay = 0) {
		yield return new WaitForSecondsRealtime (delay);
		SceneManager.LoadScene (sceneName);
	}

	IEnumerator ChangeMessageCo() { // TIME UP to GAME OVER
		MessageText.text = "TIME UP";
		yield return new WaitForSecondsRealtime (1f);
		MessageText.text = "GAME OVER";
	}

	void LoadMainMenu(float delay = 0) {
		StartCoroutine (LoadSceneDelayCo ("Main Menu", delay));
	}
}
