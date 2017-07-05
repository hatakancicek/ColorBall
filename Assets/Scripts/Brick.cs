using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    Color[] mainColors = { new Vector4(90f, 90f, 255f, 255f), new Vector4(90f, 255f, 90f, 255f), new Vector4(255f, 90f, 90f, 255f) };

    // Use this for initialization
    void Start () {
        GetComponent<SpriteRenderer>().color = mainColors[Random.Range(0, 3)] / 255;
        Debug.Log(mainColors[Random.Range(0, 3)] / 255f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Ball>())
            Destroy(gameObject);
    }
}
