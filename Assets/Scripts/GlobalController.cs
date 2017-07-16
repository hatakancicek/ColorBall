using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GlobalController : MonoBehaviour {

    /*public GameObject[] hearts;
    public GameObject canvas;
    public GameObject ballSpawner;
    public Ball ball;
    public Animator animator;
    public BrickSpawnerController brickSpawnerController;
	public Fader fader;

    private Brick[] bricks;

	void Start() {
		PlayerPrefs.SetInt ("freezeCount", 3);
		PlayerPrefs.SetInt ("superCount", 3);
		PlayerPrefs.SetInt ("suicideCount", 3);
		PlayerPrefs.SetInt ("refillCount", 3);
	}

    public void LooseLife()
    {
        if (Globals.lifeCount == 0)
            LooseGame();
        else
            hearts[--Globals.lifeCount].GetComponent<Image>().color = Color.white;
    }

    public void EarnLife()
    {
        if (Globals.lifeCount < 3)
        {
            hearts[Globals.lifeCount].GetComponent<Image>().color = new Color(1f, 24f/255f, 24f / 255f, 1f);
            Globals.lifeCount++;
        }
    }

    public void Restart()
	{
		fader.isLost = false;
		animator.SetTrigger("MakeChoice");
		RefillLife();
        Globals.lifeCount = 3;
		FindBricks();
		foreach (Brick brick in bricks)
			brick.GetComponent<Brick>().Death();
        Globals.score = 0;
        brickSpawnerController.SpawnBricks();
        if (ball.disabled)
            ball.disabled = false;
    }

    public void ContinueGame()
	{
		fader.isLost = false;
		animator.SetTrigger("MakeChoice");
        RefillLife();
        Globals.lifeCount = 3;
		FindBricks ();
        foreach (Brick brick in bricks)
            if(brick.transform.position.y < 0f)
                brick.GetComponent<Brick>().Death();
		brickSpawnerController.SpawnBricks();
        if (ball.disabled)
            ball.disabled = false;
    }

    public void LooseGame()
	{
		fader.isLost = true;
        Ball target = ballSpawner.transform.GetChild(1).GetComponent<Ball>();
        if (target)
            target.disabled = true;
        animator.SetTrigger("ShowLost");
    }

    public void SuperBall()
	{
		PlayerPrefs.SetInt ("superCount", PlayerPrefs.GetInt ("superCount", 3)-1);
		animator.SetTrigger ("MakeChoice");
		brickSpawnerController.SuperBall();
    }
		
	public void Freeze()
	{
		PlayerPrefs.SetInt ("freezeCount", PlayerPrefs.GetInt ("freezeCount", 3)-1);
		animator.SetTrigger ("MakeChoice");
		FindBricks ();
		foreach (Brick brick in bricks)
			brick.Freeze ();
		brickSpawnerController.turnsAsFrozen = 2;
	}

	public void Suicide() {
		PlayerPrefs.SetInt ("suicideCount", PlayerPrefs.GetInt ("suicideCount", 3)-1);
		animator.SetTrigger ("MakeChoice");
		FindBricks();
		foreach (Brick brick in bricks)
			brick.GetComponent<Brick>().Death();

	}

    private void RefillLife()
    {
        for (int i = 0; i < 3; i++)
            EarnLife();
    }

    private void FindBricks()
    {
        bricks = FindObjectsOfType<Brick>();
    }

	public void ShowShop() {
		animator.SetTrigger ("ShowShop");
	}

	public void ShowMenu() {
		animator.SetTrigger ("ShowMenu");
	}

	public void ShowSuperPowers() {
		animator.SetTrigger ("ShowSuperPowers");
	}

	public void ShowContinueOptions() {
		animator.SetTrigger ("ShowContinueOptions");
	}

	public void MakeChoice() {
		animator.SetTrigger ("MakeChoice");
	}

	public void GoBack() {
		SceneManager.LoadScene("Main Menu");
	}*/
}
