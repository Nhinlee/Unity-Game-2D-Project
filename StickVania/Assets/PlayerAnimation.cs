using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    // Cache component
    PlayerInput myInput;
    PlayerMovement myMovement;
    Rigidbody2D myRigid;
    Animator myAnime;

    // hash ID of Parameter in blend tree
    int speedParamID;

    // Start is called before the first frame update
    void Start()
    {
        //Get integer hashes of parameters
        speedParamID = Animator.StringToHash("speed");

        myInput = GetComponentInParent<PlayerInput>();
        myMovement = GetComponentInParent<PlayerMovement>();
        myRigid = GetComponentInParent<Rigidbody2D>();
        myAnime = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        myAnime.SetFloat(speedParamID, Mathf.Abs(myInput.horizontal));
    }
}
