using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsLogic : MonoBehaviour
{
    public OptionsController optionsPanel;

    // Start is called before the first frame update
    void Start()
    {
        optionsPanel = GameObject.FindGameObjectWithTag("Options").GetComponent<OptionsController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("ENTRAMOS");
            ShowOptions();
        }
        
    }

    public void ShowOptions()
    {
        optionsPanel.SettingsScreen.SetActive(true);
    }
}
