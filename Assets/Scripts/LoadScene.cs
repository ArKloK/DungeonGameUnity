using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

    public GameObject scoretable;

    public void OnTriggerEnter2D(Collider2D collision)
    {
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                SceneManager.LoadScene("Game");
            }
            else if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                Time.timeScale = 0f;
                scoretable.SetActive(true);
            }
    }
}
