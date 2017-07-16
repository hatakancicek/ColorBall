using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawnerController : MonoBehaviour {

    public int turnsAsFrozen = 0;
    public BrickSpawner[] brickSpawners;

<<<<<<< HEAD
<<<<<<< HEAD
	private int luckySpawnerID = 0;

=======
>>>>>>> 50557eef3abe8b20bef319023738843247cf7a0d
=======
>>>>>>> 50557eef3abe8b20bef319023738843247cf7a0d
	// Use this for initialization
	void Start () {
        SpawnBricks();
	}

    public void SpawnBricks()
    {
        if (turnsAsFrozen == 0)
        {
<<<<<<< HEAD
<<<<<<< HEAD
			while(luckySpawnerID == Globals.previouslySelectedSpawner)
            	luckySpawnerID = Random.Range(0, 5);
			Globals.previouslySelectedSpawner = luckySpawnerID;
=======
            int luckySpawnerID = Random.Range(0, 5);
>>>>>>> 50557eef3abe8b20bef319023738843247cf7a0d
=======
            int luckySpawnerID = Random.Range(0, 5);
>>>>>>> 50557eef3abe8b20bef319023738843247cf7a0d
            brickSpawners[luckySpawnerID].isLucky = true;
            foreach (BrickSpawner brickSpawner in brickSpawners)
                brickSpawner.SpawnBrick();
        }
        else
            turnsAsFrozen--;
    }

    public void SuperBall()
    {
        foreach(BrickSpawner brickSpawner in brickSpawners)
            brickSpawner.SuperBall();
    }
}