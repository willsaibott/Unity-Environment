using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
    private Paddle paddle;
    private Rigidbody2D rb;
    private Vector3 distance;
    private bool hasStarted = false;

	// Use this for initialization
	void Start () {
        paddle = GameObject.FindObjectOfType<Paddle>();
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        distance = this.transform.position - paddle.transform.position;
        print(distance);
	}

    // Update is called once per frame
    void Update() {
        if (!hasStarted) {
            // Lock the ball relative to the paddle.
            this.transform.position = paddle.transform.position + distance;

            // Wait for a mouse press to start
            if (Input.GetMouseButtonDown(0)) {
                print("Lauching ball");
                hasStarted = true;
                rb.velocity = new Vector2(0f, 15f);
            }
        }
	}
}
