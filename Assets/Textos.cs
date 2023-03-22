using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Textos : MonoBehaviour
{
    [SerializeField] private GameObject cajaTexto;
    [SerializeField] private TMP_Text texto;
    [SerializeField] private List<GameObject> listCorazones;
    [SerializeField] private Sprite corazonDesactivado;

    public void ActivarDesactivarCajaTextos(bool activar)
    {
        cajaTexto.SetActive(activar);
    }

    public void MostrarTextos (string text)
    {
        texto.text = text.ToString();
    }

    public void QuitarCorazones(int indice)
    {
        Image corazon = listCorazones[indice].GetComponent<Image>();
        corazon.sprite = corazonDesactivado;
    }

}
