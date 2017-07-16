using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;


public class GameTouchArea : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	public Action touchDownEvent;
	public Action touchUpEvent;

	public void OnPointerDown(PointerEventData eventData)
	{
		if (touchDownEvent != null)
			touchDownEvent ();
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		if (touchUpEvent != null)
			touchUpEvent ();
	}
}