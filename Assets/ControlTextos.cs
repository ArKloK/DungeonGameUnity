using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTextos : MonoBehaviour
{
    [SerializeField, TextArea(3, 10)] private string [] arrayTextos;
    [SerializeField] private Textos texto;

    private int indice;

    void OnGUI()
    {
        if (Event.current.Equals(Event.KeyboardEvent(KeyCode.Space.ToString())))
            ActivarCajaTexto();
    }
    private void OnTriggerEnter2D(Collider2D c)
    {
        texto.ActivarDesactivarCajaTextos(true);
        ActivarCajaTexto();
    }
   
    void ActivarCajaTexto()
    {
        if(indice < arrayTextos.Length)
        {
            texto.MostrarTextos(arrayTextos[indice]);
            indice++;
        }
        else
        {
            texto.ActivarDesactivarCajaTextos(false);
        }
    }
}
