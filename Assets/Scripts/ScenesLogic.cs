using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenesLogic : MonoBehaviour
{
    private void Awake()
    {
        var noDestroyBetweenScenes = FindObjectsOfType<ScenesLogic>();
        if (noDestroyBetweenScenes.Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }
}
