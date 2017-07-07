using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    public Ball ball;

	void Update ()
    {
        transform.localScale = Vector3.zero;
        if (ball.isDrag)
        {
            MoveArrow();
        }
    }

    void MoveArrow()
    {
        transform.localScale = new Vector3(0.5f, ball.newVelocity.magnitude / (-4), 1f);
        float angle = Vector3.Angle(ball.newVelocity, Vector3.right) - 90f;
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
    }
}