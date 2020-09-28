using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExtraJump : MonoBehaviour
{
    public float jumpPower;
    public float airJumpPower;
    private float distToGround;     //default distance from ground
    private bool airJump = false;
    private bool jumpBuffer = true;
    private float jumpBufferCooldown = .1f;   //prevents the jump function being called many times in a second
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();

        distToGround = (float)GetComponent<SphereCollider>().bounds.extents.y;  //calculates dist from ground
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Input.GetButton("Jump") && jumpBuffer)   //extra jump
        {
            if ( IsGrounded())
            {
                rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
                rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);

                jumpBuffer = false;

                Invoke("JumpBufferReset", jumpBufferCooldown);
            }
            else if (airJump)
            {
                rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
                rb.AddForce(Vector3.up * airJumpPower, ForceMode.Impulse);

                airJump = false;
                jumpBuffer = false;

                Invoke("JumpBufferReset", jumpBufferCooldown);
            }
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Extra Jump") && jumpBuffer)  //when picking up an extra jump
        {
            airJump = true;
        }
    }

    private void JumpBufferReset()    //refreshes the jump
    {
        jumpBuffer = true;
    }

    private bool IsGrounded()  //checks if the player is on the ground
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -Vector3.up, out hit ,distToGround + 0.1f)) //raycast to check for collision
        {
            if (hit.collider.isTrigger == false || hit.collider.gameObject.CompareTag("Moving Platform"))  //if we hit an object that isnt a pickup/checkpoint
            {
                return true;
            }
        }
    return false;
    }
}