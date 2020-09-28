using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour
{
    Camera cameraFacing;

    // Use this for initialization 
    void Start()
    {
        cameraFacing = Camera.main;

    }

    // Update is called once per frame 
    void LateUpdate()
    {
        transform.LookAt(cameraFacing.transform);
        transform.rotation = Quaternion.LookRotation(cameraFacing.transform.forward);
    }
}
