using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Body : MonoBehaviour, IPointerDownHandler
{
	public delegate void TouchDelegate ();
	public static event TouchDelegate touchEvent;

    public void OnPointerDown(PointerEventData eventData)
    {
		if (touchEvent != null)
			touchEvent ();
    }
}
