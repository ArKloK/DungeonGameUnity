using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemigo : MonoBehaviour
{
    public Transform personaje;
    public Transform [] ruta;
    private int indiceRuta;
    private UnityEngine.AI.NavMeshAgent agente;

    private void Awake()
    {
        agente = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    private void Start()
    {
        agente.updateRotation = false;
        agente.updateUpAxis = false;
    }

    private void Update()
    {
        this.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        if(this.transform.position == ruta[indiceRuta].position)
        {
            if(indiceRuta < ruta.Length -1)
            {
                indiceRuta++;
            }
            else if (indiceRuta == ruta.Length -1)
            {
                indiceRuta = 0;
            }
        }
        agente.SetDestination(ruta[indiceRuta].position);
    }
}
