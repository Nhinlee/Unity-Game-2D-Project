using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Cache Field:
    private PlayerInput myInput;              //class (component) control input of gamer
    private BoxCollider2D myBoxCollider;    //component find out the collide on my character
    private Rigidbody2D myRigid;            //physic component

    // Horizontal movement field:
    [Header("Horizontal field")]
    public float horizontalSpeed = 7f;     //Horizontal speed of character
    private int direction = 1;              //1 -> facing right, -1 -> facing left

    [Header("Jump field")]
    public float jumpForce = 7f;
    public float jumpHoldForce = 2f;
    public float jumpHoldDuration = 0.1f;
    float jumpTime;                         //Hold jump hold duration

    [Header("State Flag")]
    public bool isOnGround;
    public bool isJumping;
    


    //Method:
    private void Start()
    {
        // Reference to components:
        myInput = GetComponent<PlayerInput>();
        myBoxCollider = GetComponent<BoxCollider2D>();
        myRigid = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // Movement process:
        GroundMove();
        MidAirMove();
    }

    private void MidAirMove()
    {
        if (myInput.jumpPressed && !isJumping)
        {
            // Add Y Axis force for character jump
            myRigid.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);

            //...record the time the player will stop being able to boost their jump...
            jumpTime = Time.time + jumpHoldDuration;

            // Set isJumping to true because this time character already jumped
            isJumping = true;
        }
        else if (isJumping)
        {
            if(myInput.jumpHolding)
                myRigid.AddForce(new Vector2(0f, jumpHoldForce), ForceMode2D.Impulse);

            if (Time.time > jumpTime)
                isJumping = false;
        }
    }

    private void GroundMove()
    {
        
        // Calculate X Axis velocity:
        float xVelocity = myInput.horizontal * horizontalSpeed;
        // Flip direction:
        if (xVelocity * direction < 0)
            FlipCharacterDirection();
        // Update velocity:
        myRigid.velocity = new Vector2(xVelocity, myRigid.velocity.y);

    }

    private void FlipCharacterDirection()
    {
        //Change character direction field:
        direction *= -1;
        //Take current Xscale:
        Vector3 scale = transform.localScale;
        //Flip direction:
        scale.x *= -1;
        //Update scale:
        transform.localScale = scale;
    }
}
