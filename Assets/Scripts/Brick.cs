using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Brick : MonoBehaviour {

	public GameObject ice;
	public BoxCollider2D boxCollider;
	public SpriteRenderer spriteRenderer;

	private BrickSpawnerController controller;
	private GameController gameController;
	private bool isFrozen = false;
	private Vector3 targetPosition;

	public static Action BrickIsDead;

	private void Start() {
		FindComponents ();
		AddActions ();
		SetColor ();
		Globals.brickCount++;
		FirstFall ();
	}

	public void FindComponents() {
		gameController = FindObjectOfType<GameController> ();
		controller = FindObjectOfType<BrickSpawnerController> ();
	}

	public void AddActions() {
		if (controller)
			controller.BrickSpawn += Fall;
		if (gameController) {
			gameController.Suicide += Die;
			gameController.Continue += Continue;
			gameController.Freeze += Freeze;
			gameController.SuperBall += SuperBall;
		}
	}

	public void SetColor() {
		if(SceneManager.GetActiveScene().name == "Hard")
			spriteRenderer.color = Globals.mainColors[UnityEngine.Random.Range(0,3)]/ 255f;
		else
			spriteRenderer.color = Globals.mainColors[UnityEngine.Random.Range(1,3)] / 255f;
	}

	public void Fall()
	{
		boxCollider.isTrigger = false;
		ice.SetActive (false);
		targetPosition = transform.position + (Vector3.down * 0.8f);
		InvokeRepeating("MoveBrick", 0, 1/60f);
	}

	public void FirstFall() 
	{

		boxCollider.isTrigger = false;
		ice.SetActive (false);
		targetPosition = transform.position + (Vector3.down * 1.8f);
		InvokeRepeating("MoveBrick", 0, 1/60f);
	}

	public void Freeze() {
		ice.SetActive(true); 
		isFrozen = true;
	}

	public void SuperBall() {
		boxCollider.isTrigger = true;
	}

	public void Continue() {
		if (transform.position.y < 0)
			Die ();
	}

	public void Die() {
		controller.BrickSpawn -= Fall;
		gameController.Suicide -= Die;
		gameController.Continue -= Continue;
		gameController.Freeze -= Freeze;
		gameController.SuperBall -= SuperBall;
		Globals.brickCount--;
		Globals.score++;
		if(BrickIsDead != null)
			BrickIsDead ();

		Destroy (gameObject);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		Ball ball = collision.gameObject.GetComponent<Ball> ();
		if (ball) {
			Color ballColor = ball.GetComponent<SpriteRenderer> ().color;
			if (isFrozen)
				Die ();
			else if (ballColor == spriteRenderer.color)
				Die ();
			else if (ballColor == Color.white) {
				ball.ChangeColor (spriteRenderer.color);
				Die ();
			}
			else
				ball.ChangeColor (spriteRenderer.color);
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.GetComponent<Ball> ())
			Die ();
	}

	private void MoveBrick()
	{
		if (transform.position.y < -4 && gameController.Loose != null) {
			CancelInvoke ();
			gameController.Loose ();
		}
		else {
			transform.position = Vector3.MoveTowards (transform.position, targetPosition, 10 * Time.deltaTime);
			if (transform.position == targetPosition) {
				CancelInvoke ();
			}
		}
	}
}