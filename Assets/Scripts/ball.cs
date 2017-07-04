using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    bool isDrag = false;
    Vector3 mausePos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!isDrag)
        {
            if (Input.GetMouseButtonDown(0))
            {
                mausePos = Input.mousePosition;
                isDrag = true;
            }
        }
        else
        {
            if (Input.GetMouseButton(0))
                Debug.Log("Duration");

            else
            {
                isDrag = false;
                GetComponent<Rigidbody2D>().velocity = (mausePos - Input.mousePosition) / 15;
            }
        }
	}
}
