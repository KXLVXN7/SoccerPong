using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{

    public KeyCode moveUp = KeyCode.W;
    public KeyCode moveDown = KeyCode.S;
    [SerializeField] private bool isAI;
    public float speed = 10.0f;
    public float boundY = 3f;
    private Rigidbody2D rb2d;
    private Vector2 playerMove;
    private float smoothSpeed = 5.0f; // Kecepatan smoothing, Anda bisa menyesuaikannya
    [SerializeField] private GameObject ball;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var vel = rb2d.velocity;
        if (Input.GetKey(moveUp))
        {
            vel.y = speed;
        }
        else if (Input.GetKey(moveDown))
        {
            vel.y = -speed;
        }
        else
        {
            vel.y = 0;
        }
        rb2d.velocity = vel;

        var pos = transform.position;
        if (pos.y > boundY)
        {
            pos.y = boundY;
        }
        else if (pos.y < -boundY)
        {
            pos.y = -boundY;
        }
        transform.position = pos;
        if (isAI)
        {
            AIControl();
        }
        else
        {
            PlayerControlss();
        }
    }
    private void PlayerControlss()
    {
        playerMove = new Vector2(0, Input.GetAxisRaw("Vertical"));
    }
    private void AIControl()
    {
        if (ball.transform.position.y > transform.position. y + 0.5)
        {
            playerMove = new Vector2(0, 1);
        }
        else if (ball.transform.position.y < transform.position.y - 0.3)

        {
            playerMove = new Vector2(0, -1);
        }
        else
        {
            playerMove = new Vector2(0, 0);
        }
        Vector2 targetPosition = new Vector2(transform.position.x, ball.transform.position.y);

        // Gunakan Lerp untuk menghaluskan pergerakan
        playerMove = Vector2.Lerp(playerMove, targetPosition - (Vector2)transform.position, Time.deltaTime * smoothSpeed);
    }
    private void FixedUpdate()
    {
        rb2d.velocity = playerMove * speed;
    }
}

