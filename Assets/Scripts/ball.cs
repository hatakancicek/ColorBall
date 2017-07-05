using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    Vector3[] exPositions = {new Vector3(0f,0f,0f), new Vector3(0f,0f,0f) };
    bool isDrag = false;
    Vector3 mausePos;
    ParticleSystem ps;

	// Use this for initialization
	void Start () {
        ps = transform.GetChild(0).GetComponent<ParticleSystem>();
        ps.startColor = GetComponent<SpriteRenderer>().color;
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
                ps.Play();
            }
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Mathf.Abs(transform.position.x - exPositions[0].x) <= 0.01 && Mathf.Abs(transform.position.y - exPositions[0].y) <= 0.01)
            Destroy(gameObject);
        exPositions[0] = exPositions[1];
        exPositions[1] = transform.position;
        
    }
}
