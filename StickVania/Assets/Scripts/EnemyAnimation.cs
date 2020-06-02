using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    // Component Reference
    Animator myAnime;
    EnemyMovement myMovement;
    // Hash ID of parameter string
    int isWalkParamID;
    int isAttackParamID;
    int isRunParamID;

    private void Start()
    {
        // Hash String of parameter
        isWalkParamID = Animator.StringToHash("isWalking");
        isRunParamID = Animator.StringToHash("isRunning");
        isAttackParamID = Animator.StringToHash("isAttacking");

        // Get Component
        myAnime = GetComponent<Animator>();
        myMovement = GetComponentInParent<EnemyMovement>();
    }

    private void Update()
    {
        myAnime.SetBool(isWalkParamID, myMovement.isWalking);
        myAnime.SetBool(isRunParamID, myMovement.isRunning);
        myAnime.SetBool(isAttackParamID, myMovement.isAttacking);
    }
}
