using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    public float timeDelay = 5f;
    private bool hit=false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !hit)  //when picking up a "coin"
        {
            hit = true;

            GameObject manager = GameObject.Find("LevelManager");
            manager.GetComponent<LevelComplete>().Invoke("MoveNextLevel", timeDelay);
        }
    }
}
