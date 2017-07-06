using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottom : MonoBehaviour
{
    BrickSpawner[] spawners;
    Brick[] bricks;

    // Use this for initialization
    void Start () {
        spawners = FindObjectsOfType<BrickSpawner>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void MoveDown()
    {
        bricks = FindObjectsOfType<Brick>();
        foreach (Brick brick in bricks)
            brick.Fall();
    }

    public void SpawnBricks()
    {

        foreach (BrickSpawner spawner in spawners)
            spawner.SpawnBrick();
    }
}
