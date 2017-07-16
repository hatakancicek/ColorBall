using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LooseScreenScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void OnEnable () {
		Debug.Log ("highScore" + SceneManager.GetActiveScene ().buildIndex);
		if (Globals.score > PlayerPrefs.GetInt("highScore" + SceneManager.GetActiveScene ().buildIndex))
			PlayerPrefs.SetInt("highScore" + SceneManager.GetActiveScene ().buildIndex, Globals.score);
		GetComponent<Text>().text = "Your score: " + Globals.score + "\n\nHigh score: " + PlayerPrefs.GetInt("highScore" + SceneManager.GetActiveScene ().buildIndex);
		
	}
}