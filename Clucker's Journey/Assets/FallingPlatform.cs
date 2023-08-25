using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float fallDelay = 2.0f; // Time in seconds before the object starts falling
    public float fallSpeed = 5.0f; // Speed at which the object falls

    bool isHit = false;
    private Rigidbody2D rb2d;

    private Vector3 initialPosition;
    private Quaternion initialRotation;

    private void Start()
    {
        initialPosition = transform.position;
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!isHit)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                isHit = true;
                Invoke("StartFalling", fallDelay);
            }
        }
    }

    private void StartFalling()
    {
        rb2d.isKinematic = false;
        rb2d.velocity = Vector2.down * fallSpeed;
    }

    public void Reset()
    {
        rb2d.isKinematic = true;
        rb2d.velocity = Vector2.zero;
        rb2d.angularVelocity = 0.0f;
        transform.position = initialPosition;
        transform.rotation = initialRotation;
        isHit = false;
    }
}
