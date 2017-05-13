using UnityEngine;
using System.Collections;
using System;

public class PlayerController : MonoBehaviour {

    private float minX, maxX, minY, maxY;
    private float padding = 0.5f;
    public Vector2 speed = new Vector3(0, 0, 0);
	// Use this for initialization
	void Start () {
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftBottomCorner = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightTopCorner = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, distance));
        minX = leftBottomCorner.x + padding;
        minY = leftBottomCorner.y + padding;
        maxX = rightTopCorner.x - padding;
        maxY = rightTopCorner.y - padding;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.position -= new Vector3(speed.x * Time.deltaTime, 0, 0);
        if (Input.GetKey(KeyCode.RightArrow))
            transform.position += new Vector3(speed.x * Time.deltaTime, 0, 0);
        if (Input.GetKey(KeyCode.UpArrow))
            transform.position += new Vector3(0, speed.y * Time.deltaTime, 0);
        if (Input.GetKey(KeyCode.DownArrow))
            transform.position -= new Vector3(0, speed.y * Time.deltaTime, 0);
        if (Input.GetKey(KeyCode.S))
            shoot();

        float posX = Mathf.Clamp(transform.position.x, minX, maxX);
        float posY = Mathf.Clamp(transform.position.y, minY, maxY);
        transform.position = new Vector3(posX, posY, 0);
    }

    private void shoot() {
        print("Shoot");
    }
}
