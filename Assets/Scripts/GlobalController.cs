using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalController : MonoBehaviour {

    public GameObject[] hearts;
    public GameObject canvas;
    public GameObject ballSpawner;
    public Ball ball;
    public Animator animator;
    public BrickSpawnerController brickSpawnerController;

    private Brick[] bricks;

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
        RefillLife();
        animator.SetTrigger("Choose");
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
        RefillLife();
        animator.SetTrigger("Choose");
        Globals.lifeCount = 3;
        FindBricks();
        foreach (Brick brick in bricks)
            if(brick.transform.position.y < 0f)
                brick.GetComponent<Brick>().Death();
        brickSpawnerController.SpawnBricks();
        if (ball.disabled)
            ball.disabled = false;
    }

    public void LooseGame()
    {
        Ball target = ballSpawner.transform.GetChild(1).GetComponent<Ball>();
        if (target)
            target.disabled = true;
        animator.SetTrigger("Lost");
    }

    public void Freeze()
    {
        brickSpawnerController.turnsAsFrozen = 3;
    }

    public void SuperBall()
    {
        ball.SuperBall();
        brickSpawnerController.SuperBall();
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

}
