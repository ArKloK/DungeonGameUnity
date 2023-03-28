using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espada : MonoBehaviour
{
    private BoxCollider2D colEspada;
    private int hitsCounter;
    private int nHits;

    private void Awake()
    {
        hitsCounter = 0;
        nHits = PlayerPrefs.GetInt("lifes", 1);
        colEspada = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemigo"))
        {
            if (hitsCounter >= nHits)
            {
                Destroy(collision.gameObject);
            }
            else
                hitsCounter++;
        }
    }
}
