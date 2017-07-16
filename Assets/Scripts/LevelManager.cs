using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	private static LevelManager playerInstance;

	private void Awake(){
		DontDestroyOnLoad (this);

		if (playerInstance == null) {
			playerInstance = this;
		} else {
			DestroyObject(gameObject);
		}

		Application.targetFrameRate = 60;
	}

	private void Start () {

		Globals.freezeCount = PlayerPrefs.GetInt ("freezeCount", 3);
		Globals.superBallCount = PlayerPrefs.GetInt ("superBallCount", 3);
		Globals.suicideCount = PlayerPrefs.GetInt ("suicideCount", 3);
		Globals.goldCount = PlayerPrefs.GetInt ("goldCount", 1500);
		Globals.refillCount = PlayerPrefs.GetInt ("refillCount", 3);
	}

	public void LoadLevel(string sceneName) {
		SceneManager.LoadScene (sceneName);
	}
}