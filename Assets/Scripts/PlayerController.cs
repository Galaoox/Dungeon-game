using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private float moveHorizontal, moveVertical;
    private Animator _animator;
    [SerializeField] private float moveSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal") * moveSpeed;
        moveVertical = Input.GetAxisRaw("Vertical") * moveSpeed;
        ChangeParameterRunning();
        ChangeDirection();
    }
    
    private void ChangeParameterRunning()
    {
        _animator.SetBool("running",  moveHorizontal != 0.0f || moveVertical != 0.0f);
    }
    
    private void ChangeDirection()
    {
        if(moveHorizontal < 0.0f) transform.localScale = new Vector3( -1.0f, 1.0f, 1.0f);
        else if(moveHorizontal > 0.0f) transform.localScale = new Vector3( 1.0f, 1.0f, 1.0f);
    }
    
    void FixedUpdate()
    {
        _rigidbody2D.velocity = new Vector2(moveHorizontal, moveVertical);
    }
}
