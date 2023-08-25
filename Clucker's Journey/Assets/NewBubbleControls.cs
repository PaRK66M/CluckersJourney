using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBubbleControls : MonoBehaviour
{
    public float destroyTimer = 15f;
    private GameObject character;
    private DawnosaurPlayerMovement characterMovement;
    private Rigidbody2D characterRigidbody;
    private bool isCaptured = false;

    private Vector3 characterInitialRotation;

    public float rotationSpeed = 30.0f;

    private void Start()
    {
        Destroy(gameObject, destroyTimer);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isCaptured = true;
            characterMovement = other.GetComponent<DawnosaurPlayerMovement>();
            characterRigidbody = other.GetComponent<Rigidbody2D>();
            
            if (characterMovement != null)
                characterMovement.enabled = false;

            if (characterRigidbody != null)
                characterRigidbody.gravityScale = 0.0f;
            
            character = other.gameObject;
            characterInitialRotation = character.transform.rotation.eulerAngles;
        }
    }

    private void Update()
    {
        if(isCaptured)
        {
            character.transform.position = transform.position;
            character.transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        }

        if (isCaptured && Input.GetKeyDown(KeyCode.Space))
        {
            character.transform.rotation = Quaternion.Euler(characterInitialRotation);

            if (characterMovement != null)
                characterMovement.enabled = true;

            if (characterRigidbody != null)
                characterRigidbody.gravityScale = 1f;

            isCaptured = false;

            Destroy(gameObject);
        }
    }

    private void OnDestroy() {
        if (isCaptured)
        {
            character.transform.rotation = Quaternion.Euler(characterInitialRotation);

            if (characterMovement != null)
                characterMovement.enabled = true;

            if (characterRigidbody != null)
                characterRigidbody.gravityScale = 1f;

            isCaptured = false;
        }
    }
}
