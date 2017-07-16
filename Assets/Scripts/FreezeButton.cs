using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FreezeButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnEnable () {
		if (PlayerPrefs.GetInt ("freezeCount") <= 0)
			GetComponent<Button> ().enabled = false;
	}
}
