using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformHorizontal : MonoBehaviour
{
    [SerializeField] float _radius = 2f;       // hight = 1 -> 1 square in tile map
    [SerializeField] float _speed = 1f;
    [SerializeField] bool _vertical;
    [SerializeField] bool _horizontal;
    private Vector2 _orginalPos;
    // Cache component
    Rigidbody2D _myRigid;
    // Start is called before the first frame update
    void Start()
    {
        // Get component
        _myRigid = GetComponent<Rigidbody2D>();
        if (_vertical)
        {
            _myRigid.velocity = new Vector2(0, _speed);
        }
        else if (_horizontal)
        {
            _myRigid.velocity = new Vector2(_speed, 0);
        }
        // Get current high of this object
        _orginalPos = transform.position;
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(transform.position.y - _orginalPos.y) >= _radius
            || Mathf.Abs(transform.position.x - _orginalPos.x) >= _radius)
        {
            _myRigid.velocity *= -1;
        }
    }
   
}
