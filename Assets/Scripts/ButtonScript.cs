using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public void PlayGame()
    {
        Debug.Log("HOAL");
        SceneManager.LoadScene("Game");
    }

    public void ExitGame()
    {
        Debug.Log("Sale de la aplicacion");
        Application.Quit();
    }
}
