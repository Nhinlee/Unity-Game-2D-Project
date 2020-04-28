using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stickman : MonoBehaviour
{
    #region Private Fields
    float heal = 100f;
    bool isAlive = true;
    #endregion

    #region Serialize Fields
    [SerializeField]
    float runSpeed = 10f;
    [SerializeField]
    float jumpSpeed = 10f;
    #endregion

    #region Cached Fields
    PolygonCollider2D myBodyCollider;
    BoxCollider2D myBoxCllider;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        myBodyCollider = this.GetComponent<PolygonCollider2D>();
        myBoxCllider = this.GetComponent<BoxCollider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
