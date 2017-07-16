using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MediumButton : MonoBehaviour {

	void OnEnable () {
		if (PlayerPrefs.GetInt ("highScore1") < 99)
			GetComponent<Button> ().enabled = false;
	}
}