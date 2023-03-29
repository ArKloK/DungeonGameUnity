using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Personaje : MonoBehaviour
{
    [SerializeField] private float velocidad;

    private Rigidbody2D rigibody;

    private Animator ani;

    private SpriteRenderer spritePersonaje;

    private float posColX = 1;
    private float posColY = 0;

    private int vida;
    [SerializeField] private Textos vidaUI;

    private float tiempoAtaque = .25f;
    private float contadorAtaque = .25f;
    private bool estaAtacando;

    private void Awake()
    {
        rigibody = GetComponent<Rigidbody2D>();
        ani = GetComponentInChildren<Animator>();
        spritePersonaje = GetComponentInChildren<SpriteRenderer>();

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("GameScene1"))
        {
            Debug.Log("RESETEANDO VIDAS");
            PlayerPrefs.SetInt("vidas", 3);
            PlayerPrefs.Save();
        }

        vida = PlayerPrefs.GetInt("vidas");
        Debug.Log("nvidas pp " + vida + " en escena " + SceneManager.GetActiveScene().name);
        vidaUI.CargarCorazones();
    }

    public int getVida()
    {
        return vida;
    }

    private void Update()
    {

        if (estaAtacando)
        {
            rigibody.velocity = Vector2.zero;
            contadorAtaque -= Time.deltaTime;
            if (contadorAtaque <= 0)
            {
                ani.SetBool("Ataca", false);
                estaAtacando = false;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            contadorAtaque = tiempoAtaque;
            ani.SetBool("Ataca", true);
            estaAtacando = true;
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

        rigibody.velocity = new Vector2(horizontal, vertical) * velocidad;
        ani.SetFloat("MovX", rigibody.velocity.x);
        ani.SetFloat("MovY", rigibody.velocity.y);


        if (horizontal == 1 || horizontal == -1 || vertical == 1 || vertical == -1)
        {
            ani.SetFloat("UltMovX", horizontal);
            ani.SetFloat("UltMovY", vertical);
        }
    }

    public void CausarHerida()
    {
        vida = PlayerPrefs.GetInt("vidas");
        if (vida > 0)
        {
            vida--;
            vidaUI.QuitarCorazones(vida);
            PlayerPrefs.SetInt("vidas", vida);
            PlayerPrefs.Save();

            if (vida == 0)
            {
                Debug.Log("Has muerto");
            }
        }
    }

    public void AñadirVida()
    {
        vida = PlayerPrefs.GetInt("vidas");
        vida++;
        PlayerPrefs.SetInt("vidas", vida);
        PlayerPrefs.Save();
        vidaUI.CargarCorazones();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int nvidas = PlayerPrefs.GetInt("vidas");
        if (nvidas < 3)
        {
            if (collision.CompareTag("Corazon"))
            {
                Debug.Log("AÑADIENDO VIDA");
                Destroy(collision.gameObject);
                AñadirVida();
            }
        }

    }
}
