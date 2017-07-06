using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour {

    public GameObject ball;
    GameObject spawnedBall;
    Transform arrow;
    Ball ballBall;

    int index;
    Color[] mainColors = { new Vector4(50f,50f,255f,255f), new Vector4(50f, 255f, 50f, 255f), new Vector4(255f, 50f, 50f, 255f) };

    // Use this for initialization
    void Start () {
        SpawnBall();
        arrow = transform.GetChild(0);
    }
	
	// Update is called once per frame
	void Update () {
        if (ballBall.isDrag)
        {
            arrow.transform.localScale = Vector3.zero;
            MoveArrow();
        }
        else
        {
            arrow.transform.localScale = Vector3.zero;
        }
	}

    void SpawnBall()
    {
        spawnedBall = Instantiate(ball, transform.position, Quaternion.identity) as GameObject;
        spawnedBall.GetComponent<SpriteRenderer>().color = mainColors[1];
        spawnedBall.transform.parent = transform;
        ballBall = spawnedBall.GetComponent<Ball>();
    }

    void MoveArrow()
    {
        arrow.localScale = Vector3.zero;
        arrow.localScale = new Vector3(0.5f, ballBall.newVelocity.magnitude / (-4), 1f);
        float angle = Vector3.Angle(ballBall.newVelocity, Vector3.right) - 90f;
        arrow.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
    }
}