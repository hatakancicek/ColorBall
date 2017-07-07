using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawnerController : MonoBehaviour {

    public int turnsAsFrozen = 0;
    public BrickSpawner[] brickSpawners;

	// Use this for initialization
	void Start () {
        SpawnBricks();
	}

    public void SpawnBricks()
    {
        if (turnsAsFrozen == 0)
        {
            int luckySpawnerID = Random.Range(0, 5);
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