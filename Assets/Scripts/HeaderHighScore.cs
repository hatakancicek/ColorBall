using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HeaderHighScore : MonoBehaviour {

	private int highScore;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		int currentHighScore = PlayerPrefs.GetInt ("highScore" + SceneManager.GetActiveScene ().buildIndex);
		if(Globals.score <= currentHighScore)
			GetComponent<Text> ().text = currentHighScore.ToString();
		else
			GetComponent<Text> ().text = "New High Score: " + Globals.score;
	}
}
