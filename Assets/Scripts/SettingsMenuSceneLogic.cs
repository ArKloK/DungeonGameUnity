using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenuSceneLogic : MonoBehaviour
{
    private void Awake()
    {
        var noDestroyBetweenScenes = FindObjectsOfType<SettingsMenuSceneLogic>();
        if (noDestroyBetweenScenes.Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }
}
