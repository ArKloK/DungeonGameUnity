using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class LoadScene : MonoBehaviour
{

    public GameObject scoretable;
    private GameObject[] enemigos;
    private CircleCollider2D colider;
    [SerializeField] private GameObject muro;

    private void Start()
    {
        colider = this.gameObject.GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        enemigos = GameObject.FindGameObjectsWithTag("Enemigo");
        if (enemigos.Length == 0)
        {
            colider.enabled = true;
            muro.SetActive(false);

        }
        else
        {
            colider.enabled = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (enemigos.Length != 0)
        {
            Debug.Log("No puedes pasar");
        }
            if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            SceneManager.LoadScene("GameScene2");
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            Time.timeScale = 0f;
            scoretable.SetActive(true);
        }
    }
}
