using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawnerController : MonoBehaviour {

    public int turnsAsFrozen = 0;
    public BrickSpawner[] brickSpawners;

	private int luckySpawnerID = 0;

	// Use this for initialization
	void Start () {
        SpawnBricks();
	}

    public void SpawnBricks()
    {
        if (turnsAsFrozen == 0)
        {
			while(luckySpawnerID == Globals.previouslySelectedSpawner)
            	luckySpawnerID = Random.Range(0, 5);
			Globals.previouslySelectedSpawner = luckySpawnerID;
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