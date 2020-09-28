using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanWave : MonoBehaviour
{
    public AnimationCurve myCurve;
    private float startY;

    // Update is called once per frame
    void Start()
    {
        startY = transform.position.y;  //starting position of the ocean
    }

    void Update()
    {
        //moves it up and down based on the curve
        transform.position = new Vector3(transform.position.x, startY+ myCurve.Evaluate(Time.time % (myCurve.length+5))-.6f, transform.position.z);
    }
}
