using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    
    bool isFalling = false, isSuper = false;
    Vector2 position = new Vector2(0f,0f);

    // Use this for initialization
    void Start () {
        GetComponentInChildren<SpriteRenderer>().color = Globals.mainColors[Random.Range(1, 3)] / 255;
        Globals.brickCount++;
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

            if (collision.gameObject.GetComponent<SpriteRenderer>().color == GetComponent<SpriteRenderer>().color || collision.gameObject.GetComponent<SpriteRenderer>().color == Color.white)
            {
                GetComponent<Animator>().SetTrigger("Death");
            }
            collision.gameObject.GetComponent<Ball>().ChangeColor(GetComponent<SpriteRenderer>().color);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Ball>())
            Death();
        else
        {
            GlobalController globe = FindObjectOfType<GlobalController>();
            globe.GetComponent<GlobalController>().LooseLife();
            Death();
        }
    }

    public void Vanish()
    {
        Destroy(GetComponent<BoxCollider2D>());
    }

    public void Death()
    {
        Globals.score++;
        Globals.brickCount--;
        Destroy(gameObject);
    }

    public void Fall()
    {
        if(isSuper)
        {
            isSuper = false;
            GetComponent<BoxCollider2D>().isTrigger = false;
        }
        position = new Vector2(transform.position.x , transform.position.y - 0.8f);
        isFalling = true;
    }

    public void SuperBall()
    {
        isSuper = true;
        GetComponent<BoxCollider2D>().isTrigger = true;
    }
}