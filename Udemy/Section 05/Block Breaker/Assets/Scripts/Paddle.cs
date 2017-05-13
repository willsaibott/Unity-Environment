using UnityEngine;
using System.Collections;
using System;

public class Paddle : MonoBehaviour {

    private Ball ball;
    private float diff;
    private Rigidbody2D ballRb;
    public float velocityCoeficient = 1;
    public bool autoPlay = false;

	// Use this for initialization
	void Start () {
        ball = GameObject.FindObjectOfType<Ball>();
        ballRb = ball.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (autoPlay) autoMove();
        else          mouseMove();
	}

    private void autoMove() {
        float ballPos = ball.transform.position.x;
        Vector3 paddlePos = new Vector3(Mathf.Clamp(ballPos, 0.5f, 15.5f),
                                        this.transform.position.y,
                                        0f);
        diff = paddlePos.x - this.transform.position.x;

        this.transform.position = paddlePos;
    }

    private void mouseMove() {
        float mousePos = Input.mousePosition.x / Screen.width * 16;
        Vector3 paddlePos = new Vector3(Mathf.Clamp(mousePos, 0.5f, 15.5f),
                                        this.transform.position.y,
                                        0f);
        diff = paddlePos.x - this.transform.position.x;

        this.transform.position = paddlePos;
    }

    public void OnCollisionExit2D(Collision2D collision) {
        float xVel = velocityCoeficient * diff + UnityEngine.Random.Range(- 1f, 1f);
        float yVel = (ballRb.velocity.y > 8f)? ballRb.velocity.y: 8f;
        ballRb.velocity = new Vector2(xVel, yVel);
    }
}
