using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private BoxCollider2D colEspada;

    private Rigidbody2D rigibody;

    private Animator ani;

    private SpriteRenderer spritePersonaje;

    private float posColX = 1;
    private float posColY = 0;

    private int vida = 3;
    [SerializeField] private Textos vidaUI;


    private void Awake()
    {
        rigibody = GetComponent<Rigidbody2D>();
        ani = GetComponentInChildren<Animator>();
        spritePersonaje = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ani.SetTrigger("Ataca");
        }
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        rigibody.velocity = new Vector2(horizontal, vertical) * velocidad;
        ani.SetFloat("MovX", rigibody.velocity.x);
        ani.SetFloat("MovY", rigibody.velocity.y);
        /*ani.SetFloat("Camina", Mathf.Abs(rigibody.velocity.magnitude));
      
        if(horizontal > 0)
        {
            colEspada.offset = new Vector2(posColX, posColY);
            spritePersonaje.flipX = false;
        }
        else if(horizontal < 0)
        {
            colEspada.offset = new Vector2(-posColX, posColY);
            spritePersonaje.flipX = true;
        } */
    }

    public void CausarHerida()
    {
        if (vida > 0)
        {
            vida--;
            vidaUI.QuitarCorazones(vida);

            if(vida == 0)
            {
                Debug.Log("Has muerto");
            }
        }
    }
}
