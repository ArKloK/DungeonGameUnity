using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtacaEnemigo : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Personaje personaje = collision.gameObject.GetComponent<Personaje>();
            personaje.CausarHerida();

        }
    }
}
