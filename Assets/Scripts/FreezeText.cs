using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FreezeText : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnEnable () {
		GetComponent<Text> ().text = "x" + PlayerPrefs.GetInt ("freezeCount");
	}
}
