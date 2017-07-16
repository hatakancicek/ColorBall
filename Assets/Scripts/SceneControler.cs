using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControler : MonoBehaviour {

	public void LaunchEasy () {
		SceneManager.LoadScene ("Easy");
	}

	public void LaunchMedium () {
		SceneManager.LoadScene ("Medium");
	}

	public void LaunchHard () {
		SceneManager.LoadScene ("Hard");
	}
}
