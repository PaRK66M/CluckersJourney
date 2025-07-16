using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class DoorControls : MonoBehaviour
{
    bool padsActive = false;

    public float pressedOffsetY = 0f;
    public float pressedOffsetX = 0f;
    public float moveSpeed = 2f;

    public List<Transform> pads;

    private Vector3 doorInitialPosition;
    private Vector3 doorTargetPosition;

    void Start()
    {
        doorInitialPosition = transform.position;
        doorTargetPosition = doorInitialPosition;
    }

    void Update()
    {
        foreach(Transform pad in pads)
        {
            if (pad.position.y != pad.GetComponent<PressurePad>().initialPosition.y)
            {
                padsActive = true;
            }
        }

        if (padsActive)
        {
            doorTargetPosition = new Vector3(doorInitialPosition.x + pressedOffsetX, doorInitialPosition.y + pressedOffsetY, doorInitialPosition.z);
        }
        else
        {
            doorTargetPosition = doorInitialPosition;
        }

        transform.position = Vector3.MoveTowards(transform.position, doorTargetPosition, moveSpeed * Time.deltaTime);

        padsActive = false;
    }
}
