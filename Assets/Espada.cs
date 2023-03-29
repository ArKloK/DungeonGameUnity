using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espada : MonoBehaviour
{
    private BoxCollider2D colEspada;
    private int hitsCounter;
    private int nHits;
    public GameObject dropeableObject;

    private void Awake()
    {
        hitsCounter = 1;
        nHits = PlayerPrefs.GetInt("lifes");
        colEspada = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemigo"))
        {
            Debug.Log("NUMERO DE GOLPES " + hitsCounter);
            if (hitsCounter >= nHits)
            {
                Destroy(collision.gameObject);
                hitsCounter = 1;
            }
            else
                hitsCounter++;
        }
        if (collision.CompareTag("Chest"))
        {
            Destroy(collision.gameObject);
            Instantiate(dropeableObject,collision.transform.position,collision.transform.rotation);
        }
    }
}
