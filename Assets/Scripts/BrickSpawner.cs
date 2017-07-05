using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawner : MonoBehaviour {

    public GameObject brick;
    public float difficulty;

    // Use this for initialization
    void Start () {
        SpawnBrick();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpawnBrick()
    {
        
        if(Random.Range(0f,1f) < difficulty/100)
            Instantiate(brick, transform.position, Quaternion.identity);
    }
}
