using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector3 Velocity;
    public Vector3 lastPosition;
    
    private Rigidbody body;
    private Collider collider;
    private Animator animComp;

    // checks for movement
    public bool touchGround;
    public bool isJumping;

    // for horizontal movement
    private float axis = 0f;
    
    // for vertical movement
    private Transform initialJump;
    private float fastFall = 8f;
    
    // movement maxes
    private float maxRunSpeed = 6f;
    public float jumpForce = 12f;
    public float runForce = 20f;
    
    

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
        animComp = GetComponent<Animator>();
        axis = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        // Calculate velocity
        Velocity = (transform.position - lastPosition) / Time.deltaTime;
        lastPosition = transform.position;
        
        // check if touching ground
        float castDistance = collider.bounds.extents.y + 0.1f;
        touchGround = Physics.Raycast(transform.position, Vector3.down, castDistance);

        // get input from user
        GetInput();
        
        // move the player
        body.AddForce(Vector3.right * runForce * axis, ForceMode.Force);
        
        // jump
        if (Input.GetKeyDown(KeyCode.Space) && touchGround)
        {
            body.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumping = false;
        }
        
        // check if jump ends early
        if (Input.GetKeyUp(KeyCode.Space))
        {
            // remove the upward velocity
            Vector3 temp = body.velocity;
            body.velocity = new Vector3(temp.x, 0, temp.z);
        }
        
        

        // rotate character if going left
        if (body.velocity.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }

        // rotate character if going right
        if (body.velocity.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        
        // stop the player from going over the max speed
        if (Mathf.Abs(body.velocity.x) > maxRunSpeed)
        {
            float newX = maxRunSpeed * Mathf.Sign(body.velocity.x);
            body.velocity = new Vector3(maxRunSpeed, body.velocity.y, body.velocity.z);
        }
        
        // slow down to stop if there is no input
        if (axis < 0.2f)
        {
            float newX = body.velocity.x * (1f - Time.deltaTime * 9f);
            body.velocity = new Vector3(newX, body.velocity.y, body.velocity.z);
        }
    }

    // check what keys are being pressed
    private void GetInput()
    {
        // get horizontal input
        axis = Input.GetAxis("Horizontal");
        
        // left shift to sprint
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            maxRunSpeed = 12f;
        }

        // go back to normal run speed
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            maxRunSpeed = 6f;
        }

        if (Input.GetKeyDown(KeyCode.Space) && touchGround)
        {
            isJumping = true;
        }
        else
        {
            isJumping = false;
        }
        
    }
}
