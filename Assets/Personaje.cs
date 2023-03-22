using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private BoxCollider2D colEspada;

    private Rigidbody2D rigidbody;

    private Animator ani;

    private SpriteRenderer spritePersonaje;

    private float posColX = 1;
    private float posColY = 0;

    private int vida = 3;
    [SerializeField] private Textos vidaUI;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        ani = GetComponentInChildren<Animator>();
        spritePersonaje = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ani.SetTrigger("Ataca");
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            CausarHerida();
        }
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        rigidbody.velocity = new Vector2(horizontal, vertical) * velocidad;
        ani.SetFloat("Camina", Mathf.Abs(rigidbody.velocity.magnitude));

        if(horizontal > 0)
        {
            colEspada.offset = new Vector2(posColX, posColY);
            spritePersonaje.flipX = false;
        }
        else if(horizontal < 0)
        {
            colEspada.offset = new Vector2(-posColX, posColY);
            spritePersonaje.flipX = true;
        }
    }

    private void CausarHerida()
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
