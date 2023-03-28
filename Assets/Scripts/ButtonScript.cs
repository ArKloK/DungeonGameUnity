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
        SceneManager.LoadScene("SampleScene");
    }

    public void ExitGame()
    {
        Debug.Log("Sale de la aplicacion");
        Application.Quit();
    }

    public void EasyDifficulty()
    {
        PlayerPrefs.SetFloat("velocity", 1);
        PlayerPrefs.SetInt("lifes", 1);
        PlayerPrefs.Save();
    }

    public void MediumDifficulty()
    {
        PlayerPrefs.SetFloat("velocity", 3);
        PlayerPrefs.SetInt("lifes", 3);
        PlayerPrefs.Save();
    }

    public void HardDifficulty()
    {
        PlayerPrefs.SetFloat("velocity", 5);
        PlayerPrefs.SetInt("lifes", 5);
        PlayerPrefs.Save();
    }
}
