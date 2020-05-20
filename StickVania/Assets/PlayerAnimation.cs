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
    int verticalParamID;
    int isOnGroundParamID;

    // Start is called before the first frame update
    void Start()
    {
        //Get integer hashes of parameters
        speedParamID = Animator.StringToHash("speed");
        verticalParamID = Animator.StringToHash("verticalVelocity");
        isOnGroundParamID = Animator.StringToHash("isOnGround");

        //Get essential component of parent and this object to control animation
        myInput = GetComponentInParent<PlayerInput>();
        myMovement = GetComponentInParent<PlayerMovement>();
        myRigid = GetComponentInParent<Rigidbody2D>();
        myAnime = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        myAnime.SetFloat(speedParamID, Mathf.Abs(myInput.horizontal));
        myAnime.SetFloat(verticalParamID, myRigid.velocity.y);
        myAnime.SetBool(isOnGroundParamID, myMovement.isOnGround);
    }
}
