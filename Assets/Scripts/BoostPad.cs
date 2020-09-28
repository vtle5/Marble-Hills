using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostPad : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
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
            otherRB.AddForce(transform.forward * speed);
        }
    }
}
