using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyCounter : MonoBehaviour
{
    private static float counter;

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
    }

    public static float GetCounter()
    {
        return counter;
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        Debug.Log(counter + "\n");
    }
}
