using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyStone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);
        GameObject prince = other.gameObject;
        if (prince.tag == "Player")
        {
            prince.GetComponent<Prince>().KeyStones++;
            Destroy(gameObject);
        }
    }
}
