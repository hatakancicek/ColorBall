using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BrickSpawnerController : MonoBehaviour {

    public int turnsAsFrozen = 0;
    public BrickSpawner[] brickSpawners;
	public Bottom bottom;
	public GameController controller;

	private int luckySpawnerID = 0;

	public Action BrickSpawn;

	// Use this for initialization
	void Start () {
		bottom.ballTouchedBottom += SpawnBricks;
		controller.Freeze += Freeze;
		controller.Continue += SpawnBricks;
		controller.Suicide += SpawnBricks;
        SpawnBricks();
	}

    public void SpawnBricks()
    {
		if (turnsAsFrozen == 0 || Globals.brickCount == 0)
        {
			turnsAsFrozen = 0;
			while(luckySpawnerID == Globals.previouslySelectedSpawner)
            	luckySpawnerID = UnityEngine.Random.Range(0, 5);
			Globals.previouslySelectedSpawner = luckySpawnerID;
            brickSpawners[luckySpawnerID].isLucky = true;
			if(BrickSpawn != null)
				BrickSpawn ();
        }
        else
            turnsAsFrozen--;
    }

	public void Freeze() {
		turnsAsFrozen = 3;
	}
}