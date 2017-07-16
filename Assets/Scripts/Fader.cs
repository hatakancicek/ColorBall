using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Fader : MonoBehaviour, IPointerDownHandler
{
	public Animator animator;
	public bool isLost = false;

	public void OnPointerDown(PointerEventData eventData)
	{
		if(!isLost)
			animator.SetTrigger ("MakeChoice");
	}
}
