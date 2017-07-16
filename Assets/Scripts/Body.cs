using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Body : MonoBehaviour, IPointerDownHandler
{
    public Ball ball;

    public void OnPointerDown(PointerEventData eventData)
    {
        ball.isDrag = true;
        ball.startPosition = Input.mousePosition;
    }
}
