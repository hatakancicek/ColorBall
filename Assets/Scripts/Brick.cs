using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    Color[] mainColors = { new Vector4(90f, 90f, 255f, 255f), new Vector4(90f, 255f, 90f, 255f), new Vector4(255f, 90f, 90f, 255f) };
    bool isFalling = false;
    Vector2 position = new Vector2(0f,0f);

    // Use this for initialization
    void Start () {
        GetComponentInChildren<SpriteRenderer>().color = mainColors[Random.Range(1, 3)] / 255;
	}
	
	// Update is called once per frame
	void Update () {
		if (isFalling)
        {
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), position, 5 * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Ball>()) {

            if (collision.gameObject.GetComponent<SpriteRenderer>().color == GetComponent<SpriteRenderer>().color || collision.gameObject.GetComponent<SpriteRenderer>().color == new Color(50f, 255f, 50f, 255f))
            {
                GetComponent<Animator>().SetTrigger("Death");
            }
            collision.gameObject.GetComponent<Ball>().ChangeColor(GetComponent<SpriteRenderer>().color);
        }

        if (collision.gameObject.GetComponent<Finish>())
        {
            Debug.Log("Lost");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Lost");
    }

    public void Vanish()
    {
        Destroy(GetComponent<BoxCollider2D>());
    }

    public void Death()
    {
        Destroy(gameObject);
    }

    public void Fall()
    {
        position = new Vector2(transform.position.x , transform.position.y - 0.8f);
        isFalling = true;
    }
}