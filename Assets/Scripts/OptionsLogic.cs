using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsLogic : MonoBehaviour
{
    public OptionsController optionsPanel;
    private bool gamePaused;

    // Start is called before the first frame update
    void Start()
    {
        gamePaused = false;
        optionsPanel = GameObject.FindGameObjectWithTag("Options").GetComponent<OptionsController>();
    }

    // Update is called once per frame
    void Update()
    {
        //It only opens the option panel if the current scene is not MenuPrincipal
        if (!SceneManager.GetSceneByName("MenuPrincipal").isLoaded)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (gamePaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }
    }

    public void ShowOptions()
    {
        optionsPanel.SettingsScreen.SetActive(true);
    }

    public void Pause()
    {
        gamePaused = true;
        Time.timeScale = 0f;
        optionsPanel.SettingsScreen.SetActive(true);
    }

    public void Resume()
    {
        gamePaused = false;
        Time.timeScale = 1f;
        optionsPanel.SettingsScreen.SetActive(false);
    }
}
