using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    Vector3[] exPositions = {new Vector3(0f,-20f,0f), new Vector3(0f,-20f,0f) };
    bool isDrag = false, isLaunched = false, isResetting = false;
    Vector3 mausePos;
    ParticleSystem ps;
    int loopCount = 0;

	// Use this for initialization
	void Start () {
        ps = transform.GetChild(0).GetComponent<ParticleSystem>();
        ps.startColor = GetComponent<SpriteRenderer>().color;
	}
	
	// Update is called once per frame
	void Update () {

        if (!isLaunched) {
            if (!isDrag)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    mausePos = Input.mousePosition;
                    isDrag = true;
                }
            }
            else
            {
                if (Input.GetMouseButtonUp(0))
                {
                    isDrag = false;
                    if (mausePos.y - Input.mousePosition.y > 0)
                    {
                        GetComponent<Rigidbody2D>().velocity = (mausePos - Input.mousePosition) / 35;
                        ps.Play();
                        isLaunched = true;
                    }
                }
            }
        }

        else if(isResetting)
        {
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2(0, -4f), 3 * Time.deltaTime);
            if (transform.position == new Vector3(0, -4f, 0f))
            {
                exPositions[0] = new Vector3(0f, -20f, 0f);
                exPositions[1] = new Vector3(0f, -20f, 0f);
                ps.Stop();
                isResetting = false;
                isLaunched = false;
                loopCount = 0;
                GetComponent<CircleCollider2D>().enabled = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Mathf.Abs(transform.position.y - exPositions[1].y) == 0)
        {
            if (++loopCount == 5)
            {
                ResetBall();
            }
        }


        else if (collision.gameObject.GetComponent<Bottom>())
            ResetBall();
        
        exPositions[1] = exPositions[0];
        exPositions[0] = transform.position;
    }

    private void ResetBall()
    {
        GetComponent<CircleCollider2D>().enabled = false;
        BrickSpawner[] spawners = FindObjectsOfType<BrickSpawner>();
        foreach (BrickSpawner spawner in spawners)
            spawner.SpawnBrick();
        Brick[] bricks = FindObjectsOfType<Brick>();
        foreach (Brick brick in bricks)
            brick.Fall();
        GetComponent<Rigidbody2D>().velocity = new Vector3(0f, 0f, 0f);
        isResetting = true;
    }

    public void ChangeColor(Color col)
    {
        GetComponent<SpriteRenderer>().color = col;
        ps.startColor = GetComponent<SpriteRenderer>().color;
    }
}
