using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Parameter ID in Animator controller
    int _isOpenParamID;
    // Cache component
    Animator _myAnime;
    private void Start()
    {
        // Get component
        _myAnime = GetComponent<Animator>();
        // String to hash
        _isOpenParamID = Animator.StringToHash("isOpen");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject prince = collision.gameObject;
        if (prince.tag.Equals("Player") && prince.GetComponent<Prince>().KeyStones >= 2)
        {
            _myAnime.SetTrigger(_isOpenParamID);
        }
    }
}
