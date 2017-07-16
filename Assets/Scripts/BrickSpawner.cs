using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawner : MonoBehaviour {

    public GameObject brick;
    public float difficulty;
    public bool isLucky = false;

    public void SuperBall()
    {
        foreach (Brick brick in GetComponentsInChildren<Brick>())
        {
            brick.SuperBall();
        }
    }

    public void SpawnBrick()
    {
<<<<<<< HEAD
<<<<<<< HEAD
		if(Random.Range(0f,1f) < (difficulty - Globals.brickCount * 9) / 100f  || isLucky)
            Instantiate(brick, transform.position, Quaternion.identity).transform.parent = transform;
        if(difficulty < 90f)
            difficulty += 0.7f;
=======
=======
>>>>>>> 50557eef3abe8b20bef319023738843247cf7a0d
        if(Random.Range(0f,1f) <( difficulty - Globals.brickCount * 3 )/ 100 || isLucky)
            Instantiate(brick, transform.position, Quaternion.identity).transform.parent = transform;
        if(difficulty < 60f)
            difficulty += 0.1f;
<<<<<<< HEAD
>>>>>>> 50557eef3abe8b20bef319023738843247cf7a0d
=======
>>>>>>> 50557eef3abe8b20bef319023738843247cf7a0d
        isLucky = false;
        foreach (Brick brick in GetComponentsInChildren<Brick>())
            brick.Fall();
    }
}