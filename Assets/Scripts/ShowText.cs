using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowText : MonoBehaviour
{
    public Transform playerTransform;
    public GameObject textObject;
    public float distanceToShowText=6;

    void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, playerTransform.position) < distanceToShowText)
        {
            textObject.SetActive(true);
        }
        else
        {
            textObject.SetActive(false);
        }
    }
}
