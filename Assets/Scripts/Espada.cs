using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Espada : MonoBehaviour
{
    private BoxCollider2D colEspada;
    private int hitsCounter;
    private int nHits;
    public GameObject dropeableObject;
    [SerializeField] private AudioClip[] audioclips;

    private void Awake()
    {
        hitsCounter = 1;
        nHits = PlayerPrefs.GetInt("lifes");
        colEspada = GetComponent<BoxCollider2D>();
    }

    private void OnEnable()
    {
        int randomnum = (int)Random.Range(0, 4);
        Sounds.instance.EjecutarSonido(audioclips[randomnum]);
    }

    ContactPoint2D contactPoint2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemigo"))
        {
            Debug.Log("NUMERO DE GOLPES " + hitsCounter);
            if (hitsCounter >= nHits)
            {
                hitsCounter = 1;
                Destroy(collision.gameObject);
            }
            else
                hitsCounter++;
        }

        if (collision.CompareTag("Chest"))
        {
            Destroy(collision.gameObject);
            Instantiate(dropeableObject, collision.transform.position, collision.transform.rotation);
        }
    }
}
