using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AtacaEnemigo : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;

    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Personaje personaje = collision.gameObject.GetComponent<Personaje>();
            personaje.CausarHerida();
            Sounds.instance.EjecutarSonido(audioClip);
        }
    }
}
