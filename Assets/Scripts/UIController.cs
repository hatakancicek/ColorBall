using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {

	public GameObject shop;
	public GameObject superPowers;
	public GameObject looseScreen;
	public GameObject game;
	public LevelManager levelManager;
	public Text gameScoreText;
	public Text gameHighScoreText;
	public Text looseScoreText;
	public Text gameFreezeCount;
	public Text gameSuicideCount;
	public Text gameSuperBallCount;
	public Text goldCount;

	private GameController gameController;

	private void Awake() {
		Brick.BrickIsDead = null;
	}

	private void Start() {
		gameController = FindObjectOfType<GameController> ();
		gameController.Loose += Loose;
		Brick.BrickIsDead += UpdateGameScore;
		Globals.score = 0;
		Globals.brickCount = 0;
		Globals.highScore = PlayerPrefs.GetInt ("highScore" + SceneManager.GetActiveScene ().name, 0);
		gameScoreText.text = Globals.score.ToString();
		gameHighScoreText.text = Globals.highScore.ToString();
	}

	public void ShowSuperPowers() {
		gameFreezeCount.text = "x" + Globals.freezeCount;
		gameSuperBallCount.text = "x" + Globals.superBallCount;
		gameSuicideCount.text = "x" + Globals.suicideCount;
		superPowers.SetActive (true);
	}

	public void HideSuperPowers() {
		superPowers.SetActive (false);
	}

	public void ShowShop() {
		superPowers.SetActive (false);
		goldCount.text = Globals.goldCount.ToString();
		shop.SetActive (true);
	}

	public void HideShop() {
		ShowSuperPowers ();
		shop.SetActive (false);
	}

	public void ChooseSuperPower(string power) {

		if (gameController) {
			switch (power) {
			case "Freeze":
				if (Globals.freezeCount > 0) {
					Globals.freezeCount--;
					PlayerPrefs.SetInt ("freezeCount", Globals.freezeCount);
					if (gameController.Freeze != null)
						gameController.Freeze ();
					HideSuperPowers ();
				}
				break;

			case "Super Ball":
				if (Globals.superBallCount > 0) {
					Globals.superBallCount--;
					PlayerPrefs.SetInt ("superBallCount", Globals.superBallCount);
					if (gameController.SuperBall != null)
						gameController.SuperBall ();
					HideSuperPowers ();
				}
				break;

			case "Suicide":
				if (Globals.suicideCount > 0) {
					Globals.suicideCount--;
					PlayerPrefs.SetInt ("suicideCount", Globals.suicideCount);
					if (gameController.Suicide != null)
						gameController.Suicide ();
					HideSuperPowers ();
				}
				break;
			}
		}
	}

	public void BuyItem(string name) {
		switch (name) {
		case "Freeze":
			if (SpendMoney(500)){
				Globals.freezeCount += 3;
				PlayerPrefs.SetInt ("freezeCount", Globals.freezeCount);
			}
			break;

		case "Super Ball":
			if (SpendMoney (600)) {
				Globals.superBallCount += 3;
				PlayerPrefs.SetInt ("superBallCount", Globals.superBallCount);
			}
			break;

		case "Suicide":
			if (SpendMoney(700)){
				Globals.suicideCount += 3;
				PlayerPrefs.SetInt ("suicideCount", Globals.suicideCount);
			}
			break;

		case "Refill":
			if (SpendMoney(2000)){
				Globals.refillCount += 3;
				PlayerPrefs.SetInt ("refillCount", Globals.refillCount);
			}
			break;

		case "Small Gold":
			if (BuyMechanism()) {
				TakeMoney (2000);
			}
			break;

		case "Medium Gold":
			if (BuyMechanism()) {
				TakeMoney (12000);
			}
			break;		
		
		case "Large Gold":
			if (BuyMechanism()) {
				TakeMoney (50000);
			}
			break;
		}

		goldCount.text = Globals.goldCount.ToString();
	}

	public bool BuyMechanism () {
		return true;
	}

	public void TakeMoney(int amount) {
		Globals.goldCount += amount;
		PlayerPrefs.SetInt ("goldCount", Globals.goldCount);
	}

	public bool SpendMoney(int amount) {
		if (amount < Globals.goldCount) {
			Globals.goldCount -= amount;
			PlayerPrefs.SetInt ("goldCount", Globals.goldCount);
			return true;
		} else
			return false;
	}

	public void Restart() {
		levelManager.LoadLevel (SceneManager.GetActiveScene ().name);
	}

	public void ShowLost() {
		looseScoreText.text ="Your Score: " + Globals.score.ToString () + "\nHigh Score: " + Globals.highScore.ToString ();
		game.SetActive (false);
		looseScreen.SetActive (true);
	}

	public void HideLost() {
		game.SetActive (true);
		looseScreen.SetActive (false);
	}

	public void Loose() {
		if (Globals.score > Globals.highScore) {
			PlayerPrefs.SetInt ("highScore" + SceneManager.GetActiveScene ().name, Globals.score);
			Globals.highScore = Globals.score;
		}
		ShowLost ();
	}

	public void UpdateGameScore() {
		gameScoreText.text = Globals.score.ToString();
	}
}