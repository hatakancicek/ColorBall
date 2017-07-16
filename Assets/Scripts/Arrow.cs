using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

	public Ball ball;

	private GameTouchArea gameTouchArea;

	void Start() {
		gameTouchArea = FindObjectOfType<GameTouchArea> ();
		if (gameTouchArea) {
			gameTouchArea.touchDownEvent += DragStart;
			gameTouchArea.touchUpEvent += DragEnd;
		}
		transform.localScale = Vector3.zero;
	}

	private void DragStart() {
		InvokeRepeating ("DragStay", 0, 1 / 60f);
	}

	private void DragStay() {
		MoveArrow ();
	}

	private void DragEnd() {
		CancelInvoke ();
		transform.localScale = Vector3.zero;
	}

	void MoveArrow()
    {
		Vector3 ballVelocity = ball.GetLaunchVelocity ();
		float angle = Vector3.Angle(ballVelocity, Vector3.right) - 90f;
		transform.localScale = new Vector3(0.5f, ballVelocity.magnitude / (-6), 1f);
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
    }
}