using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bottom : MonoBehaviour
{
	public Action ballTouchedBottom;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.GetComponent<Ball> ())
			if(ballTouchedBottom!= null)
				ballTouchedBottom ();
	}
}
