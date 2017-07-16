using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

<<<<<<< HEAD
	public bool isDrag = false, disabled = false, isEasy = false;
=======
    public bool isDrag = false, disabled = false;
>>>>>>> 50557eef3abe8b20bef319023738843247cf7a0d
    public ParticleSystem particles;
    public CircleCollider2D circleCollider;
    public Rigidbody2D rigidBody;
    public SpriteRenderer spriteRenderer;
    public BrickSpawnerController brickSpawnerController;
    public Transform arrow;
    public Vector2 newVelocity = Vector2.zero;
    public Vector3 startPosition;

<<<<<<< HEAD
=======

>>>>>>> 50557eef3abe8b20bef319023738843247cf7a0d
    private bool isLaunched = false, isResetting = false, isSuper = false;
    private int loopCount = 0;
    private Vector3 targetPosition;
    private Vector3 basicVector = new Vector3(0f, -20f, 0f);
    private Vector3[] exPositions = {new Vector3(0f,-20f,0f), new Vector3(0f,-20f,0f) };
<<<<<<< HEAD

	void Awake() {
		Application.targetFrameRate = 60;
	}
=======
>>>>>>> 50557eef3abe8b20bef319023738843247cf7a0d

    // Use this for initialization
    void Start ()
    {
        targetPosition = transform.parent.position;
#pragma warning disable CS0618 // Type or member is obsolete
        particles.startColor = GetComponent<SpriteRenderer>().color;
#pragma warning restore CS0618 // Type or member is obsolete
        spriteRenderer.color = Color.white;
    }
	
	// Update is called once per frame
	void Update () {
        if (!disabled)
        {
            if (!isLaunched && isDrag)
            {
                CalculateVelocity();

                if (Input.GetMouseButtonUp(0) && isDrag)
                {
                    LaunchBall();
                    isDrag = false;
                }
            }

            else if (isResetting)
            {
                MoveBall();
            }

        }
    }

    public void ChangeColor(Color color)
    {
        spriteRenderer.color = color;
#pragma warning disable CS0618 // Type or member is obsolete
        particles.startColor = color;
#pragma warning restore CS0618 // Type or member is obsolete
    }

    public void SuperBall()
    {
        ChangeColor(new Color(255f, 215f, 0));
        isSuper = true;
    }

    private void MoveBall()
    {
        transform.position = Vector2.MoveTowards((Vector2)transform.position, targetPosition, 10 * Time.deltaTime);
        if (((Vector2)(transform.position - targetPosition)).magnitude < 0.001f)
        {
            exPositions[0] = basicVector;
            exPositions[1] = basicVector;
            particles.Stop();
            isResetting = false;
            isLaunched = false;
            loopCount = 0;
            GetComponent<CircleCollider2D>().enabled = true;
        }
    }

    private void LaunchBall()
    {
        if (newVelocity.magnitude > 0)
        {
            isDrag = false;
            rigidBody.velocity = newVelocity;
            particles.Play();
            isLaunched = true;
        }

        newVelocity = Vector2.zero;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Bottom>()) {
            ResetBall();
            brickSpawnerController.SpawnBricks();
        }
<<<<<<< HEAD
		else if(!(collision.gameObject.GetComponent<Brick>()))
=======
        else
>>>>>>> 50557eef3abe8b20bef319023738843247cf7a0d
            CheckLoop();
    }

    private void CheckLoop()
    {
        if (Mathf.Abs(transform.position.y - exPositions[1].y) < 0.030)
        {
            if (++loopCount == 5)
            {
				BreakLoop();
            }
        }

        exPositions[1] = exPositions[0];
        exPositions[0] = transform.position;
    }

    private void CalculateVelocity()
    {
        if (startPosition.y - Input.mousePosition.y > 0)
        {
            Vector2 temp = new Vector3();

            temp = (startPosition - Input.mousePosition) / 20;
            if (temp.magnitude < 3f)
                temp = Vector2.zero;

            else if (temp.magnitude > 20f)
            {
                temp.Normalize();
                temp *= 20f;
            }

            newVelocity = temp;
        }
    }

<<<<<<< HEAD
	private void BreakLoop () {
		if (isSuper) {
			ChangeColor (Color.white);
			isSuper = false;
		}
		circleCollider.enabled = false;
		rigidBody.velocity = Vector3.zero;
		newVelocity = Vector3.zero;
		isResetting = true;
	}

    private void ResetBall()
    {
		if (!isEasy) {
			if (isSuper) {
				ChangeColor (Color.white);
				isSuper = false;
			}
			circleCollider.enabled = false;
			rigidBody.velocity = Vector3.zero;
			newVelocity = Vector3.zero;
			isResetting = true;
		} else {
			rigidBody.velocity = Vector3.zero;
			transform.position = new Vector3 (transform.position.x, -4f, 0f);
			if (isSuper) {
				ChangeColor (Color.white);
				isSuper = false;
			}
			exPositions [0] = basicVector;
			exPositions [1] = basicVector;
			particles.Stop ();
			isResetting = false;
			isLaunched = false;
			loopCount = 0;
			newVelocity = Vector3.zero;
		}
=======
    private void ResetBall()
    {
        if (isSuper)
        {
            ChangeColor(Color.white);
            isSuper = false;
        }
        circleCollider.enabled = false;
        rigidBody.velocity = Vector3.zero;
        newVelocity = Vector3.zero;
        isResetting = true;
>>>>>>> 50557eef3abe8b20bef319023738843247cf7a0d
    }
}