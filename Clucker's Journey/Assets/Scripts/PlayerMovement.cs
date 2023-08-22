using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpPower;
    public float jumpDecrease = 2;
    private float currentJumpPower;
    private bool jumpStart;

    private float movementX;
    private float movementY;
    private bool jump;
    private bool grounded;

    private Vector2 velocity;

    public Rigidbody2D playerRb;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        jumpStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        jump = Input.GetButtonDown("Jump");
        if (jump && (grounded || !jumpStart))
        {
            if (jumpStart)
            {
                currentJumpPower = jumpPower;
                jumpStart = false;
            }
            playerRb.velocity = new Vector2(playerRb.velocity.x, currentJumpPower);
            currentJumpPower /= jumpDecrease;
            Debug.Log("Jumping " + currentJumpPower);
        }

        if(movementX != 0)
        {
            transform.localScale = new Vector3(-movementX, transform.localScale.y, transform.localScale.z);
        }
    }

    private void FixedUpdate()
    {
        playerRb.velocity = new Vector2(movementX * speed, playerRb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
            jumpStart = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }
}
