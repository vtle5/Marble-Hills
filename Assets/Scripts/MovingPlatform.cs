using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform platform;
    public Transform point1;
    public Transform point2;
    public int targetPoint = 2;     //current destination
    public int moveSpeed = 2;

    private Vector3 targetVector;

    // Start is called before the first frame update
    void Start()
    {
        if (targetPoint==1)
        {
            targetVector = point1.position;
        }
        if (targetPoint == 2)
        {
            targetVector = point2.position;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        platform.position = Vector3.MoveTowards(platform.position, targetVector, moveSpeed* Time.deltaTime);
        if (Vector3.Distance(platform.position,targetVector)<.01f)
        {
            if (targetPoint == 1)
            {
                targetPoint = 2;
                targetVector = point2.position;
            }
            else if (targetPoint == 2)
            {
                targetPoint = 1;
                targetVector = point1.position;
            }
        }
    }

    void OnDrawGizmos()
    {
        // Draw a semitransparent red cube at the transforms position
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(point1.position, new Vector3(2, .5f, 2));
        Gizmos.DrawCube(point2.position, new Vector3(2, .5f, 2));
    }
}
