using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : MonoBehaviour
{
    public GameObject PickupEffect;
    public int points;      //points awarded
    // Start is called before the first frame update
    public void Pickup(GameObject player)
    {
        gameObject.SetActive(false);    //deactivate pickup, maybe something can turn it on again?
        player.gameObject.GetComponent<PlayerController>().UpdateScore(points); //award points

        GameObject effect = Instantiate(PickupEffect, transform.position, new Quaternion(0, 0, 0, 0));  //create pickup effect
        Destroy(effect, 1f);    //destroy pickup effect after 1 second
    }
}
