using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    public int level;
    public int score;


    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (level > 0)
        {
            Invoke("UpdateScore", .1f);
        }
    }


    public void MoveNextLevel()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            score = player.GetComponent<PlayerController>().score;
        }
        level++;
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene(level, LoadSceneMode.Single);
    }

    // Update is called once per frame
    void UpdateScore()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            player.GetComponent<PlayerController>().UpdateScore(score);
        }
    }
}
