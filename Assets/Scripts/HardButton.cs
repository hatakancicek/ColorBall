using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HardButton : MonoBehaviour {

	void OnEnable () {
		if (PlayerPrefs.GetInt ("highScore2") < 99)
			GetComponent<Button> ().enabled = false;
	}
}
