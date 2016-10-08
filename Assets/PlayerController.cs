using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private Transform transform;
    private Rigidbody2D rigidbody;
    private float move;

    public float velocity = 10f;
    public Camera camera;

    // Use this for initialization
    void Start() {
        initialize();
    }

    // Update is called once per frame (Physics)
    void FixedUpdate() {

        // check if input is present for movement
        move = Input.GetAxis("Horizontal");

        if (move > 0f) {
            move = 1f;
        } else if (move < 0f) {
            move = -1f;
        } else {
            move = 0f;
        }

        rigidbody.AddForce(new Vector2(move * velocity, 0f), ForceMode2D.Force);
        camera.transform.position = new Vector3(
            transform.position.x * 0.8f,
            transform.position.y * 0.8f,
            -10f);

        //Debug.Log(move);
    }

    private void initialize() {

        transform = GetComponent<Transform>();
        rigidbody = GetComponent<Rigidbody2D>();
        move = 0f;
    }
}
