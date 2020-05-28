using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prince : MonoBehaviour
{
    private bool isAlive;
    public int KeyStones { get; set; }
    public int Health { get; set; }

    public Prince()
    {
        isAlive = true;
        Health = 100;   
        KeyStones = 0;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CheckAlive();
    }

    private void CheckAlive()
    {
        if (Health <= 0)
        {
            isAlive = false;
            Destroy(gameObject, 1f);
        }
    }
}
