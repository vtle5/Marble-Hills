using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour
{
    public float boostMultiplier = 1.4f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))  //when picking up a "coin"
        {
            other.gameObject.GetComponent<Rigidbody>().velocity *= boostMultiplier;
        }
    }
}
