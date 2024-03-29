﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour {

	public ParticleSystem particles;
	public CircleCollider2D circleCollider;
	public Rigidbody2D rigidBody;
	public SpriteRenderer spriteRenderer;
	public Bottom bottom;
	public GameController controller;

	private GameTouchArea gameTouchArea;
	private Vector3 launchVelocity, targetPosition, dragStartPosition;
	private Vector3[] exPositions = {new Vector3(-20f,-20f,-20f), new Vector3(-20f,-20f,-20f)};
	private int loopCount = 0;

    // Use this for initialization
    void Start ()
    {
		targetPosition = transform.position;
		particles.Stop ();
        particles.startColor = GetComponent<SpriteRenderer>().color;
        spriteRenderer.color = Color.white;
		gameTouchArea = FindObjectOfType<GameTouchArea> ();
		if (gameTouchArea) {
			gameTouchArea.touchDownEvent += DragStart;
			gameTouchArea.touchUpEvent += DragEnd;
		}
		if (bottom)
			bottom.ballTouchedBottom += ResetBall;
		controller.SuperBall += SuperBall;

    }

	public void LoopCheck() {
		Debug.Log (Mathf.Abs (exPositions [0].y - transform.position.y));
		if (Mathf.Abs(exPositions [0].y - transform.position.y) < 0.02f) {
			loopCount++;
			if (loopCount >= 5)
				ResetBall ();
		} else {
			exPositions [0] = exPositions [1];
			exPositions [1] = transform.position;
		}
	}

	private void DragStart() {
		dragStartPosition = Input.mousePosition;
		InvokeRepeating ("DragStay", 0, 1 / 60f);
		launchVelocity = Vector3.zero;
	}

	private void DragStay() {
		CalculateVelocity ();
	}

	private void DragEnd() {
		CancelInvoke ();
		if (launchVelocity.magnitude > Vector3.zero.magnitude) {
			gameTouchArea.gameObject.SetActive (false);
			rigidBody.velocity = launchVelocity;
			particles.Play ();
		}
	}

    public void ChangeColor(Color color)
    {
        spriteRenderer.color = color;
        particles.startColor = color;
    }

	private void MoveBall()
    {
        transform.position = Vector2.MoveTowards((Vector2)transform.position, targetPosition, 10 * Time.deltaTime);
		if (transform.position == targetPosition) {
			CancelInvoke ();
			gameTouchArea.gameObject.SetActive (true);
		}
    }

    private void CalculateVelocity()
	{
		Vector3 tempVelocity = new Vector3();
		if (dragStartPosition.y - Input.mousePosition.y > 0)
        {

			tempVelocity = (dragStartPosition - Input.mousePosition) / 20;
			if (tempVelocity.magnitude < 3f)
				tempVelocity = Vector3.zero;

			else if (tempVelocity.magnitude > 20f)
            {
				tempVelocity.Normalize();
				tempVelocity *= 20f;
            }
		}
		launchVelocity = tempVelocity;
    }

	public Vector3 GetLaunchVelocity() {
		return launchVelocity;
	}

	public void ResetBall() {
		loopCount = 0;
		exPositions [0] = new Vector3 (-20f, -20f, -20f);
		exPositions [1] = exPositions [0];
		rigidBody.velocity = Vector3.zero;
		particles.Stop ();
		if (spriteRenderer.color == Globals.gold)
			ChangeColor (Color.white);
		if (SceneManager.GetActiveScene().name == "Easy")
			targetPosition = new Vector3 (transform.position.x, -4.5f, 0);

		InvokeRepeating ("MoveBall", 0, 1 / 60f);
	}

	public void SuperBall() {
		ChangeColor(Globals.gold);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (!(collision.gameObject.GetComponent<Brick> ()))
			LoopCheck ();
	}

}