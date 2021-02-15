// Nathaniel Shetler
// 15 February 2021
// Course: Senior Seminor (Senior Project)
// Parts of this script were reused from scripts I wrote in my Interactive Game Design course

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class playerController : MonoBehaviour
{
    // For the player rigidbody
    private Rigidbody playerRB;

    // Variable for the player speed
    public float playerSpeed = 0.0f;

    // Variables for the movement directions
    private float xMovement, yMovement;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the player rigidbody
        playerRB = GetComponent<Rigidbody>();
    }
    
    // Called when any of the action "Move" keys are pressed
    // This is part of the new InputSystem
    void OnMove(InputValue movementVal)
    {
        // For the keyboard
        Keyboard keyboard = Keyboard.current;

        // Get movement vector from the movementVal passed to the function
        Vector2 movementVec = movementVal.Get<Vector2>();

        // Set x and y movement
        xMovement = movementVec.x;
        yMovement = movementVec.y;

        // This block will roatate the player based on the direction they are moving
        if (keyboard.dKey.isPressed || keyboard.rightArrowKey.isPressed)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (keyboard.aKey.isPressed || keyboard.leftArrowKey.isPressed)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else if (keyboard.sKey.isPressed || keyboard.downArrowKey.isPressed)
        {
            transform.localRotation = Quaternion.Euler(0, 90, 0);
        }
        else if (keyboard.wKey.isPressed || keyboard.upArrowKey.isPressed)
        {
            transform.localRotation = Quaternion.Euler(0, -90, 0);
        }
    }

    // Player's position will be updated in the function
    void FixedUpdate()
    {
        // Get vector3 for movement
        // Adjustments were made here to accomodate the camera being to the right side of the player
        Vector3 playerMovement = new Vector3(-1 * yMovement, 0.0f, xMovement);

        // Add force to player rigidbody based on the variable playerSpeed
        playerRB.AddForce(playerMovement * playerSpeed);

    }
}
