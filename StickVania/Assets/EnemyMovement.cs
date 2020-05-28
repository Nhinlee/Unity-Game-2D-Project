using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Component Reference
    BoxCollider2D myBoxCollider;
    Rigidbody2D myRigid;

    // Enemy Movement Speed
    [Header("Enemy Speed")]
    public float _walkSpeed = 1.3f;
    public float _runSpeed = 3.5f;
    // Physic check field
    [Header("Physics Check")]
    public float _footHorOffset = 0.3f;
    public float _footVerOffset = 0.1f;
    public float _footCheckLength = 0.35f;
    public LayerMask groundMask;

    // Detective player field
    [Header("Detective Player")]
    public float _eyesRayLength = 8f;
    public LayerMask playerMask;

    // Detective attack zone
    [Header("Detective AttackZone")]
    public float _AxeRayLength = 0.98f;

    // BoxCollider field
    Vector2 _boxColliderOffset;
    Vector2 _boxColliderSize;

    // Direction and Velocity
    int _direction;

    // Flag Field
    public bool isWalking;
    public bool isRunning;
    public bool isAttacking;
    

    private void Start()
    {
        // Get component
        myBoxCollider = GetComponent<BoxCollider2D>();
        myRigid = GetComponent<Rigidbody2D>();

        // Get Offset and Size of BoxCollider2D
        _boxColliderOffset = myBoxCollider.offset;
        _boxColliderSize = myBoxCollider.size;

        // Take direction of character
        _direction = Math.Sign(transform.localScale.x);

        // Set Origin Velocity
        myRigid.velocity = new Vector2(_walkSpeed, 0f);
    }

    private void FixedUpdate()
    {
        ResetFlag();
        PhysicCheck();
        DetectiveAttackZone();
        DetectivePlayer();
        GroundMove();
    }

    private void DetectiveAttackZone()
    {
        // Raycast2D from eyes to dectect Attack Zone
        Vector2 midPos = new Vector2(0f, _boxColliderSize.y / 2) + (Vector2)transform.position;
        Vector2 midDirection = _direction == 1 ? Vector2.right : Vector2.left;
        RaycastHit2D midHit = RequireMethod.RayCast(midPos, midDirection, _AxeRayLength, playerMask);

        //
        if (midHit)
        {
            isAttacking = true;
        }
    }

    private void ResetFlag()
    {
        isRunning = false;
        isWalking = false;
        isAttacking = false;
    }

    private void DetectivePlayer()
    {
        // Raycast2D from eyes to dectect player
        Vector2 eyesPos = new Vector2(0f, _boxColliderSize.y * 3 / 4) + (Vector2)transform.position;
        Vector2 eyesDirection = _direction == 1 ? Vector2.right : Vector2.left;
        RaycastHit2D eyesHit = RequireMethod.RayCast(eyesPos, eyesDirection, _eyesRayLength, playerMask);

        //
        if (eyesHit && !isAttacking)
        {
            isRunning = true;
        }
        else if (!isAttacking)
        {
            isWalking = true;
        }
    }

    private void GroundMove()
    {
        // Update Velocity
        if (isAttacking)
            myRigid.velocity = Vector2.zero;
        if (isRunning)
            myRigid.velocity = new Vector2(_runSpeed * _direction, 0f);
        if (isWalking)
            myRigid.velocity = new Vector2(_walkSpeed * _direction, 0f);
    }

    private void PhysicCheck()
    {
        // Raycast2D check position to decide turn back or not
        Vector2 rightFoot = new Vector2(myBoxCollider.size.x / 2 + _footHorOffset, _footVerOffset) + (Vector2)transform.position;
        Vector2 leftFoot = new Vector2(-(myBoxCollider.size.x / 2 + _footHorOffset), _footVerOffset) + (Vector2)transform.position;
        RaycastHit2D rightFootHit = RequireMethod.RayCast(rightFoot, Vector2.down, _footCheckLength, groundMask); 
        RaycastHit2D leftFootHit = RequireMethod.RayCast( leftFoot, Vector2.down, _footCheckLength, groundMask);

        if (!rightFootHit || !leftFootHit)
        {
            FlipCharacter();
        }
    }

    private void FlipCharacter()
    {
        //Change character direction field:
        _direction *= -1;
        //Take current Xscale:
        Vector3 scale = transform.localScale;
        //Flip direction:
        scale.x *= -1;
        //Update scale:
        transform.localScale = scale;
    }
}
