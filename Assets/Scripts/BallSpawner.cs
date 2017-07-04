using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour {

    public int[] balls;
    public GameObject ball;

    int index;
    Color[] ballColors = { new Vector4(50f,50f,255f,255f), new Vector4(50f, 255f, 50f, 255f), new Vector4(255f, 50f, 50f, 255f) };

    // Use this for initialization
    void Start () {
        SpawnBall();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SpawnBall()
    {
        GameObject spawnedBall = Instantiate(ball, transform.position, Quaternion.identity) as GameObject;
        spawnedBall.GetComponent<SpriteRenderer>().color = ballColors[1];
    }
}