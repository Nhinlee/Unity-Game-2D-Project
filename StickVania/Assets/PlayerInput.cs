using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[DefaultExecutionOrder(-100)]
public class PlayerInput : MonoBehaviour
{
    private bool isReadyToClear;

    // Input field:
    [HideInInspector] public float horizontal;
    [HideInInspector] public bool jumpPressed;
    [HideInInspector] public bool jumpHolding;
    // Method:
   
    private void FixedUpdate()
    {
        // Clear out of all input before and go to Update() and use current input
        isReadyToClear = true;  
    }

    private void Update()
    {
        if(isReadyToClear)
            ClearInput();
        // Process Input:
        ProcessInput();
    }

    private void ProcessInput()
    {
        // Horizontal input:
        horizontal += Input.GetAxis("Horizontal");
        // Jump Input:
        jumpPressed = jumpPressed || Input.GetButtonDown("Jump");
        jumpHolding = jumpHolding || Input.GetButton("Jump");
    }

    private void ClearInput()
    {
        horizontal = 0f;

        jumpPressed = false;
        jumpHolding = false;

        isReadyToClear = false;
    }
}
