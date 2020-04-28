using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickmanInput : MonoBehaviour
{
    [HideInInspector] public float horizontal; // Float that stores X input;
    [HideInInspector] public bool JumpHeld; // Bool that stores jump held;
    [HideInInspector] public bool JumpPressed; // Bool that stores jump pressed;

    bool readyToClear;

    private void Update()
    {
        // Clear out existing input values:
        ClearInput();

        //If the Game Manager says the game is over, exit
        if (GameManager.isGameOver())
            return;

        //Process Input in your laptop:
        ProcessInput();
    }

    private void FixedUpdate()
    {
        // This Flag to be ensure that all code gets to use the current inputs
        readyToClear = true;
    }
    private void ClearInput()
    {
        if (!readyToClear)
            return;

        horizontal = 0f;
        JumpPressed = false;
        JumpHeld = false;
    }

    private void ProcessInput()
    {
        // Horizontal Axis input:
        horizontal += Input.GetAxis("Horizontal");

        // Button input:
        JumpPressed = JumpPressed || Input.GetButton("Jump");
        JumpHeld = JumpHeld || Input.GetButtonDown("Jump");
    }

   
}
