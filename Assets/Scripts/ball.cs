﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public bool isDrag = false, disabled = false;
    public Vector2 newVelocity;
    public Vector3 mausePos;
   
    Transform arrow;
    Vector3[] exPositions = {new Vector3(0f,-20f,0f), new Vector3(0f,-20f,0f) };
    bool isLaunched = false, isResetting = false;
    ParticleSystem ps;
    int loopCount = 0;
    Rigidbody2D rb;
    Vector3 targetPosition;

    // Use this for initialization
    void Start ()
    {
        targetPosition = transform.parent.position;
        newVelocity = Vector2.zero;
        rb = GetComponent<Rigidbody2D>();
        ps = transform.GetChild(0).GetComponent<ParticleSystem>();
        ps.startColor = GetComponent<SpriteRenderer>().color;
	}
	
	// Update is called once per frame
	void Update () {
        if (!disabled)
        {

            if (!isLaunched)
            {

                CalculateVelocity();

                if (Input.GetMouseButtonDown(0))
                {
                    mausePos = Input.mousePosition;
                    isDrag = true;
                }

                else if (Input.GetMouseButtonUp(0) && isDrag)
                {
                    LaunchBall();
                    isDrag = false;
                }
            }

            else if (isResetting)
            {
                MoveBall();
            }

        }
    }

    void MoveBall()
    {
        transform.position = Vector2.MoveTowards((Vector2)transform.position, targetPosition, 10 * Time.deltaTime);
        if (((Vector2)(transform.position - targetPosition)).magnitude < 0.001f)
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

    void LaunchBall()
    {
        if (newVelocity.magnitude > 0)
        {
            isDrag = false;
            rb.velocity = newVelocity;
            ps.Play();
            isLaunched = true;
        }

        newVelocity = Vector2.zero;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Bottom>()) {
            ResetBall();
            collision.gameObject.GetComponent<Bottom>().SpawnBricks();
            collision.gameObject.GetComponent<Bottom>().MoveDown();
        }
        else
            checkLoop();
    }

    void checkLoop()
    {
        if (Mathf.Abs(transform.position.y - exPositions[1].y) < 0.001)
        {
            if (++loopCount == 5)
            {
                ResetBall();
            }

            exPositions[1] = exPositions[0];
            exPositions[0] = transform.position;
        }
    }

    void CalculateVelocity()
    {
        if (mausePos.y - Input.mousePosition.y > 0)
        {
            Vector2 temp = new Vector3();

            temp = (mausePos - Input.mousePosition) / 20;
            if (temp.magnitude < 3f)
                temp = Vector2.zero;

            else if (temp.magnitude > 20f)
            {
                temp.Normalize();
                temp *= 20f;
            }

            newVelocity = temp;
        }
    }

    void ResetBall()
    {
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().velocity = new Vector3(0f, 0f, 0f);
        newVelocity = Vector3.zero;
        isResetting = true;
    }

    public void ChangeColor(Color col)
    {
        GetComponent<SpriteRenderer>().color = col;
        ps.startColor = GetComponent<SpriteRenderer>().color;
    }
}