using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float force;

    private void OnTriggerEnter(Collider other)
    {
        push(other);
    }

    private void OnTriggerStay(Collider other)
    {
        push(other);
    }

    private void push(Collider other)
    {
        Rigidbody otherRB = other.GetComponent<Rigidbody>();
        if (otherRB != null)
        {
            otherRB.AddForce(0,force,0);
        }
    }
}
