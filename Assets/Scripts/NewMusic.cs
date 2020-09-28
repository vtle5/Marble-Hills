using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewMusic : MonoBehaviour
{
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        GameObject mus = GameObject.FindGameObjectWithTag("EndMus");
        Destroy(mus);
        GameObject manager = GameObject.Find("LevelManager");
        
        scoreText.text = "Score: " + manager.GetComponent<LevelComplete>().score.ToString();

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
