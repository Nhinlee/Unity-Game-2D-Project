using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// I learn this logic and souce code from: Unity Platform Create On Youtube
/// </summary>
public class StickmanMovement : MonoBehaviour
{
    [Header("Movement Properties")]
    public float speed = 8f;                // Player Speed
    public float jumpDuration = .5f;        // How long the player can jump after falling
    public float maxFallSpeed = -25f;       // Max speed player can fall

    [Header("Jump Properties")]
    public float jumpForce = 6.3f;          // Initial force of jump
    public float hangingJumpForce = 15f;    // Force of wall hanging jump
    public float jumpHoldFore = 1.9f;       // Force of holding jump
    public float jumpHoldDuration = .1f;    // How long the jumpkey can be hold

    [Header("Environment Check Properties")]
    public float footOffset = .4f;          // X offset of feet raycast
    public float eyeHeight = 1.5f;          // Height of wall checks
    public float reachOffset = .7f;         // X offset for wall grapping 
    public float headClearance = .5f;       // Space needed above the player's head
    public float groundDistance = .2f;      // Distance player is considered to be on the ground
    public float grabDistance = .4f;        // The reach distance for wall grabs
    public LayerMask groundLayer;			// Layer of the ground

    [Header("Status Flags")]
    public bool isOnGround;                 // Is the player on the ground?
    public bool isJumping;                  // Is player jumping?
    public bool isHanging;					// Is player hanging?

    StickmanInput input;                    // The current inputs for the player
    BoxCollider2D bodyCollider;             // The collider component
    Rigidbody2D rigidBody;					// The rigidbody component

    float jumpTime;                         // Variable to hold jump duration
    float coyoteTime;                       // Variable to hold coyote duration
    float playerHeight;						// Height of the player

    float originalXScale;                   // Original scale on X axis
    int direction = 1;			    // Direction player is facing

    Vector2 colliderStandSize;
    Vector2 colliderStandOffset;
    private bool drawDebugRaycasts = true;
    private Vector3 posVariance;            // This is variance between actual postion and rigidbody position

    private void Start()
    {
        // Initial value variance based on analyst unity editor
        posVariance = new Vector3(0, 0.3f, 0f);

        // Get a reference to the required components
        input = GetComponent<StickmanInput>();
        bodyCollider = GetComponent<BoxCollider2D>();
        rigidBody = GetComponent<Rigidbody2D>();

        //Record the original x scale of the player
        originalXScale = transform.localScale.x;

        //Record the player's height from the collider
        playerHeight = bodyCollider.size.y;

        //Record initial collider size and offset
        colliderStandSize = bodyCollider.size;
        colliderStandOffset = bodyCollider.offset;
    }

    private void FixedUpdate()
    {
        // Check the environment to determine status
        PhysicsCheck();

        // Movement process
        GroundMovement();
    }

    private void GroundMovement()
    {

        // Calculated desired velocity based on input horizontal
        float xVelociy = input.horizontal * speed;

        // Facing right way
        if (xVelociy * direction < 0f)
            FlipCharacterDirection();

        // Apply the desired velocity to rigidbody2D
        rigidBody.velocity = new Vector2(xVelociy, rigidBody.velocity.y);

    }

    private void PhysicsCheck()
    {
        // Start by assuming the player isn't on the ground and the head isn't blocked
        bool isOnGround = false;
        /*bool isHeadBlocked = false;*/

        //Cast rays for the left and right foot
        RaycastHit2D leftCheck = Raycast(new Vector2(0, 0), Vector2.down, groundDistance);
        RaycastHit2D rightCheck;
        if (direction == 1)
        {
            rightCheck = Raycast(new Vector2(footOffset, 0), Vector2.down, groundDistance);
        }
        else
        {
            rightCheck = Raycast(new Vector2(-footOffset, 0), Vector2.down, groundDistance);
        }

        //If either ray hit the ground, the player is on the ground
        if (leftCheck || rightCheck)
        {
            isOnGround = true;
        }

    }

    void FlipCharacterDirection()
    {
        // Turn the character by flipping the direction
        direction *= -1;

        // Record the curr scale
        Vector3 scale = transform.localScale;

        // Flip by multi the X scale to direction
        scale.x = originalXScale * direction;

        // Apply the new scale
        transform.localScale = scale;
    }

    //These two Raycast methods wrap the Physics2D.Raycast() and provide some extra
    //functionality
    RaycastHit2D Raycast(Vector2 offset, Vector2 rayDirection, float length)
    {
        //Call the overloaded Raycast() method using the ground layermask and return 
        //the results
        return Raycast(offset, rayDirection, length, groundLayer);
    }

    RaycastHit2D Raycast(Vector2 offset, Vector2 rayDirection, float length, LayerMask mask)
    {
        //Record the player's position
        Vector2 pos = transform.position + posVariance;

        //Send out the desired raycasr and record the result
        RaycastHit2D hit = Physics2D.Raycast(pos + offset, rayDirection, length, mask);

        //If we want to show debug raycasts in the scene...
        if (drawDebugRaycasts)
        {
            //...determine the color based on if the raycast hit...
            Color color = hit ? Color.red : Color.green;
            //...and draw the ray in the scene view
            Debug.DrawRay(pos + offset, rayDirection * length, color);
        }

        //Return the results of the raycast
        return hit;
    }
}
