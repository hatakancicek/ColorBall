using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    Vector3[] exPositions = {new Vector3(0f,0f,0f), new Vector3(0f,0f,0f) };
    bool isDrag = false, isLaunched = false;
    Vector3 mausePos;
    ParticleSystem ps;

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
                        GetComponent<Rigidbody2D>().velocity = (mausePos - Input.mousePosition) / 15;
                        ps.Play();
                        isLaunched = true;
                    }
                }
            }
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Mathf.Abs(transform.position.y - exPositions[0].y) <= 0.01)
            ResetBall();

        else if (collision.gameObject.GetComponent<Bottom>())
            ResetBall();

        else if (collision.gameObject.GetComponent<Brick>())
        {
            GetComponent<SpriteRenderer>().color = collision.gameObject.GetComponent<SpriteRenderer>().color;
            ps.startColor = GetComponent<SpriteRenderer>().color;
        }
    }

    private void ResetBall()
    {
        transform.Translate(new Vector3(0,0,0));
    }
}
