using UnityEngine;
using System.Collections;
using System;

public class PlayerController : MonoBehaviour {

    private Transform transform;
    private Rigidbody2D rigidbody;
    private float move;
    private float jump;
    private bool facingRight;
    private bool grounded;

    public float velocity = 10f;
    public float jumpForce = 100f;
    public Camera camera;

    // Use this for initialization
    void Start() {
        initialize();
    }

    // Update is called once per frame (Physics)
    void FixedUpdate() {

        if (grounded) {

            // check if input is present for movement
            move = Input.GetAxis("Horizontal");

            if (move > 0f) {
                move = 1f;
                facingRight = true;
                flip();
            } else if (move < 0f) {
                move = -1f;
                facingRight = false;
                flip();
            } else {
                move = 0f;
            }

            if (Input.GetKeyDown(KeyCode.Space)) {
                jump = 1f;
            }

            rigidbody.AddForce(new Vector2(
                   move * velocity,
                   jump * jumpForce),
                   ForceMode2D.Force);
        } else {
            move = 0f;
            jump = 0f;
        }

        camera.transform.position = new Vector3(
            transform.position.x * 0.8f,
            transform.position.y * 0.8f,
            -10f);

        //Debug.Log(move);
        Debug.Log("Grounded: " + grounded);
    }

    private void flip() {
        if (facingRight) {
            transform.localScale = new Vector2(1f, 1f);
        } else {
            transform.localScale = new Vector2(-1f, 1f);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {

        if (other.gameObject.CompareTag("Platform")) {
            grounded = true;
        }
    }

    public void OnCollisionExit2D(Collision2D other) {

        grounded = false;
    }

    private void initialize() {

        transform = GetComponent<Transform>();
        rigidbody = GetComponent<Rigidbody2D>();
        move = 0f;
        facingRight = true;
        grounded = false;
    }
}
