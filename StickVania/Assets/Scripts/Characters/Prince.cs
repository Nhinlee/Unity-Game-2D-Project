using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prince : MonoBehaviour
{
    #region Fields
    private bool isAlive;                   // Flag to consider when prince die
    
    #endregion Fields
    public int KeyStones { get; set; }      // KeyStones to open the door
    public int Health { get; set; }         // Health of prince

    // Cache component
    PlayerAnimation myAnime;
    Rigidbody2D myRigid;
    public Prince()
    {
        // Original set when prince is created
        isAlive = true;
        Health = 1000;   
    }
    // Start is called before the first frame update
    void Start()
    {
        // Get nessesary component
        myAnime = GetComponentInChildren<PlayerAnimation>();
        myRigid = GetComponent<Rigidbody2D>();
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Damage")
        {
            // Subtract prince health
            Health -= 10;
            // Play animation
            myAnime.Hurting();
            // Add some movement make prince so get dame from enemy or dammp thing.
            RequireMethod.HurtingMovement(myRigid);
        } else if (other.gameObject.tag == "KeyStone")
        {
            // Add keystone
            KeyStones += 1; 
            // Destroy KeyStone
            other.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Destroy(other.gameObject);
        }
    }
}
