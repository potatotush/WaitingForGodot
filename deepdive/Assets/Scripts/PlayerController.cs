using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody theRB;

    // Variables: moveSpeed is how fast you're going, and jumpForce is how high you jump
    public float moveSpeed, jumpforce;

     
    private Vector2 moveInput;

    public LayerMask whatIsGround;
    public Transform groundPoint;
    private bool isGrounded;

    public SpriteRenderer theSR;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        moveInput.Normalize();

        theRB.linearVelocity = new Vector3(moveInput.x * moveSpeed, theRB.linearVelocity.y, moveInput.y * moveSpeed);

        RaycastHit hit;
        if(Physics.Raycast(groundPoint.position, Vector3.down, out hit, 1f, whatIsGround))
        {
            isGrounded = true;
        } else
        {
            isGrounded = false;
        }

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            theRB.linearVelocity += new Vector3(0f, jumpforce, 0f);
        }

        if(!theSR.flipX && moveInput.x<0)
        {
            theSR.flipX=true;
        } else if(theSR.flipX && moveInput.x>0)
        {
            theSR.flipX=false;
        }
    }
}
