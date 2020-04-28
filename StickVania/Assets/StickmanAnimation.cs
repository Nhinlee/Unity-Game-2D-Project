using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickmanAnimation : MonoBehaviour
{
    // Cached component
    StickmanInput input;
    Animator anim;

    int speedParamID;       // Save ID of speed Pramameter

    private void Start()
    {
        // Get references to the needed components
        anim = GetComponent<Animator>();
        input = GetComponent<StickmanInput>();

        // Get the integer hashes of the parameters. This is much more efficient
        // than passing strings into the animator
        speedParamID = Animator.StringToHash("speed");

    }

    private void Update()
    {
        // Use the absolute value of speed so that we only pass in positive numbers
        anim.SetFloat(speedParamID, Mathf.Abs(input.horizontal));
    }
}
