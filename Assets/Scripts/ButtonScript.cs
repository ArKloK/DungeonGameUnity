using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup[] Menus;

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

    public void OpenSingle(CanvasGroup canvas)
    {
        Debug.Log("ENTRA");
        foreach (CanvasGroup c in Menus)
        {
            Debug.Log("Entra en bucle");
            CloseSingle(c);
        }
        
        canvas.alpha = canvas.alpha > 0 ? 0 : 1;
        canvas.blocksRaycasts = canvas.blocksRaycasts == true ? false : true;
    }

    public void CloseSingle(CanvasGroup canvas)
    {
        canvas.alpha = 0;
        canvas.blocksRaycasts = false;
    }
}
