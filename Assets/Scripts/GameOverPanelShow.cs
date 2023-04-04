using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPanelShow : MonoBehaviour
{
    public GameObject gameover;
    [SerializeField] private AudioClip audioClip;

    private void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameover == null)
        {
            Debug.Log("PANEL ES NULO");
        }
        else
        {
            if (PlayerPrefs.GetInt("vidas")==0)
            {
                gameover.SetActive(true);
                Time.timeScale = 0f;
                Sounds.instance.EjecutarSonido(audioClip);
            }
        }
    }
}
