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
    int _speedParamID;
    int _verticalParamID;
    int _isOnGroundParamID;
    int _isHurtingParamID;

    // Start is called before the first frame update
    void Start()
    {
        //Get integer hashes of parameters
        _speedParamID = Animator.StringToHash("speed");
        _verticalParamID = Animator.StringToHash("verticalVelocity");
        _isOnGroundParamID = Animator.StringToHash("isOnGround");
        _isHurtingParamID = Animator.StringToHash("isHurting");

        //Get essential component of parent and this object to control animation
        myInput = GetComponentInParent<PlayerInput>();
        myMovement = GetComponentInParent<PlayerMovement>();
        myRigid = GetComponentInParent<Rigidbody2D>();
        myAnime = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        myAnime.SetFloat(_speedParamID, Mathf.Abs(myInput.horizontal));
        myAnime.SetFloat(_verticalParamID, myRigid.velocity.y);
        myAnime.SetBool(_isOnGroundParamID, myMovement.isOnGround);
    }

    public void Hurting()
    {
        myAnime.SetTrigger(_isHurtingParamID);
    }

}
