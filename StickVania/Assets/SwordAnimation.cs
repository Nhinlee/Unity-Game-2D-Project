using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAnimation : MonoBehaviour
{
    // Cache Component
    Animator myAnime;
    PlayerInput playerInput;

    // Hash ID of parameters
    int isSwordAttack1;
    // Start is called before the first frame update
    void Start()
    {
        // Get component
        myAnime = GetComponent<Animator>();
        playerInput = GetComponentInParent<PlayerInput>();
        // Get animator parameter
        isSwordAttack1 = Animator.StringToHash("isSwordAttack1");
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        myAnime.SetBool(isSwordAttack1, playerInput.attack);
    }
}
