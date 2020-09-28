using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public float dashPower=800;
    private Rigidbody rb;
    private float distToGround;     //default distance from ground
    public TrailRenderer trail;
    private bool canDash = true;
    public GameObject startingDashEffect;
    // Start is called before the first frame update
    void Start()
    {
        trail.emitting = false;
        rb = gameObject.GetComponent<Rigidbody>();

        distToGround = (float)GetComponent<SphereCollider>().bounds.extents.y;  //calculates dist from ground
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            GameObject effect = Instantiate(startingDashEffect, transform.position, new Quaternion(0, 0, 0, 0));  //create dash effect
            Destroy(effect, 1f);    //destroy after 1 second
            rb.isKinematic = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) && canDash)
        {
            rb.isKinematic = false;         //make sure this is disabled first
            trail.emitting = true;
            Vector3 targetDirection = Camera.main.GetComponent<CameraController>().groundPos.forward; //localizes movement with camera
            rb.AddForce(targetDirection * dashPower);   //moves the ball
            Invoke("StopTrail", 3f);
            canDash = false;
        }

        if (IsGrounded()) {
            canDash = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Extra Dash"))  //when picking up an extra jump
        {
            canDash = true;
        }
    }

    private bool IsGrounded()  //checks if the player is on the ground
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -Vector3.up, out hit ,distToGround + 0.1f)) //raycast to check for collision
        {
            if (hit.collider.isTrigger == false)  //if we hit an object that isnt a pickup/checkpoint
            {
                return true;
            }
        }
    return false;
    }

    private void StopTrail()
    {
        trail.emitting = false;
    }

}