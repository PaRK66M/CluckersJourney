using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float fallDelay = 2.0f; // Time in seconds before the object starts falling
    public float fallSpeed = 5.0f; // Speed at which the object falls

    private bool isPlayerOnCollider = false;
    private Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerOnCollider = true;
            Invoke("StartFalling", fallDelay);
        }
    }

    private void StartFalling()
    {
        if (isPlayerOnCollider)
        {
            rb2d.isKinematic = false;
            rb2d.velocity = Vector2.down * fallSpeed;
            Destroy(gameObject, 5f);
        }
    }
}
