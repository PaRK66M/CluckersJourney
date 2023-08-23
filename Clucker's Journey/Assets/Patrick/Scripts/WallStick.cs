using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallStick : MonoBehaviour
{
    public DawnosaurPlayerMovement movementScript;

    void StickToWall()
    {
        movementScript.RB.velocity = new Vector2(movementScript.RB.velocity.x, 0);
        movementScript.currentJumpForce = movementScript.Data.jumpForce;
        movementScript._isStuckOnWall = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6) //Checks for ground layer as walls will be on the ground layer
        {
            if(movementScript.LastOnGroundTime < 0)
            {
                if (movementScript._moveInput.x != 0)
                {
                    StickToWall();

                }
            }
        }
            
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        movementScript._isStuckOnWall = false;
        Debug.Log("Pushed out");
    }


}
