using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalController : MonoBehaviour {

    public GameObject[] hearts;
    public GameObject canvas;
    public GameObject ballSpawner;

    Brick[] bricks;
    Animator animator;

    void Start()
    {
        animator = canvas.GetComponent<Animator>();
    }

    public void LooseLife()
    {
        if (Global.lifeCount == 0)
            LooseGame();
        else
            hearts[--Global.lifeCount].GetComponent<Image>().color = Color.white;
    }

    public void EarnLife()
    {
        if (Global.lifeCount < 3)
        {
            hearts[Global.lifeCount].GetComponent<Image>().color = new Color(1f, 24f/255f, 24f / 255f, 1f);
            Global.lifeCount++;
        }
    }

    public void Restart()
    {
        Global.lifeCount = 3;
        bricks = FindObjectsOfType<Brick>();
        foreach (Brick brick in bricks)
           brick.GetComponent<Brick>().Death();

    }

    void ContinueGame()
    {

        bricks = FindObjectsOfType<Brick>();
        foreach (Brick brick in bricks)
            if (brick.transform.position.y < 0f)
                brick.GetComponent<Brick>().Death();
        animator.SetTrigger("Choose");
        Ball target = ballSpawner.transform.GetChild(1).GetComponent<Ball>();

        if (target)
            target.disabled = false;
    }

    public void LooseGame()
    {
        Ball target = ballSpawner.transform.GetChild(1).GetComponent<Ball>();
        if (target)
            target.disabled = true;
        animator.SetTrigger("Lost");
    }

    public void UpdateScore()
    {

    }
}
