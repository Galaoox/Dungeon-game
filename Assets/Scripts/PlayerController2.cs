using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool moveLeft;
    private bool moveRight;
    private bool moveUp;
    private bool moveDown;
    private float horizontalMove;
    private float verticalMove;
    public float speed = 5;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        moveLeft = false;
        moveRight = false;
    }

    public void PointerDownLeft()
    {
        moveLeft = true;
    }

    public void PointerUpLeft()
    {
        moveLeft = false;
    }
    
    public void PointerDownRight()
    {
        moveRight = true;
    }

    public void PointerUpRight()
    {
        moveRight = false;
    }
    
    public void PointerDownMoveUp()
    {
        moveUp = true;
    }

    public void PointerUpMoveUp()
    {
        moveUp = false;
    }
    
    public void PointerDownMoveDown()
    {
        moveDown = true;
    }

    public void PointerUpMoveDown()
    {
        moveDown = false;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        if (moveLeft)
        {
            horizontalMove = -speed;
        }
        else if (moveRight)
        {
            horizontalMove = speed;
        }
        else if (moveUp)
        {
            verticalMove = speed;
        }
        else if (moveDown)
        {
            verticalMove = -speed;
        }
        else
        {
            horizontalMove = 0;
            verticalMove = 0;
        }
        
        
    }

    public void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMove, verticalMove);
        ChangeParameterRunning();
        ChangeDirection();
    }
    
    private void ChangeParameterRunning()
    {
        animator.SetBool("running",  horizontalMove != 0.0f || verticalMove != 0.0f);
    }
    
    private void ChangeDirection()
    {
        if(horizontalMove < 0.0f) transform.localScale = new Vector3( -1.0f, 1.0f, 1.0f);
        else if(horizontalMove > 0.0f) transform.localScale = new Vector3( 1.0f, 1.0f, 1.0f);
    }
}
