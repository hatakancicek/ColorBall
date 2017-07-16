using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuicideButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnEnable () {
		if (PlayerPrefs.GetInt ("suicideCount") <= 0)
			GetComponent<Button> ().enabled = false;
	}
}
