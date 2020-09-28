using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotDestroy : MonoBehaviour
{
    public GameObject DestroyEffect;
    // Start is called before the first frame update
    public void Pickup(GameObject player)
    {
        gameObject.SetActive(false);

        GameObject effect = Instantiate(DestroyEffect, transform.position, new Quaternion(0, 0, 0, 0));  //create destroy effect
        Destroy(effect, 3f);    //destroy after 3 seconds
    }
}
