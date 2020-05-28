using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject prince = other.gameObject;
        if(prince.tag == "Player")
        {
            prince.GetComponent<Prince>().Health -= 10;
        }
    }
}
