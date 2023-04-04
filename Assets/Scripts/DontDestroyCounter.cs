using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyCounter : MonoBehaviour
{
    private static float counter;
    [SerializeField] private AudioClip audioClip;

    private void Awake()
    {
        var noDestroyBetweenScenes = FindObjectsOfType<DontDestroyCounter>();
        if (noDestroyBetweenScenes.Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        Sounds.instance.EjecutarSonido(audioClip);
    }

    public static float GetCounter()
    {
        return counter;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MenuPrincipal"))
        {
            Debug.Log("ESCENA MENU PRINCIPAL");
            Destroy(gameObject);
        }
        counter += Time.deltaTime;
        //Debug.Log(counter + "\n");
    }
}
