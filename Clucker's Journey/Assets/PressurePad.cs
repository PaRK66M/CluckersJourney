using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressurePad : MonoBehaviour
{
    public float pressedOffset = 1f; 
    public float moveSpeed = 2f;

    public Vector3 initialPosition;
    private Vector3 targetPosition;

    private bool isPressed = false;

    private void Start()
    {
        initialPosition = transform.position;
        targetPosition = initialPosition;
    }

    private void Update()
    {
        if (isPressed)
        {
            targetPosition = new Vector3(initialPosition.x, initialPosition.y - pressedOffset, initialPosition.z);
        }
        else
        {
            targetPosition = initialPosition;
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Adjust the tag accordingly
        {
            isPressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Adjust the tag accordingly
        {
            isPressed = false;
        }
    }
}
