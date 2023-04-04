using UnityEngine;
using System.Collections;
using System;

namespace Pathfinding
{
    /// <summary>
    /// Sets the destination of an AI to the position of a specified object.
    /// This component should be attached to a GameObject together with a movement script such as AIPath, RichAI or AILerp.
    /// This component will then make the AI move towards the <see cref="target"/> set on this component.
    ///
    /// See: <see cref="Pathfinding.IAstarAI.destination"/>
    ///
    /// [Open online documentation to see images]
    /// </summary>
    [UniqueComponent(tag = "ai.destination")]
    [HelpURL("http://arongranberg.com/astar/docs/class_pathfinding_1_1_a_i_destination_setter.php")]
    public class AIDestinationSetter : VersionedMonoBehaviour
    {
        /// <summary>The object that the AI should move to</summary>
        public Transform target;
        IAstarAI ai;
        public Transform[] ruta;
        float velocity;
        bool detectado;
        private int indiceRuta;
        private SpriteRenderer sprite;
        private Transform objetivo;
        private Animator ani;
        private Rigidbody2D rigidbody2;

        private void Awake()
        {
            ani = GetComponentInChildren<Animator>();
            sprite = GetComponentInChildren<SpriteRenderer>();
            velocity = PlayerPrefs.GetFloat("velocity", 1);
        }

        void Start()
        {
            rigidbody2 = GetComponent<Rigidbody2D>();
            indiceRuta = 0;
        }

        void OnEnable()
        {
            ai = GetComponent<IAstarAI>();
            // Update the destination right before searching for a path as well.
            // This is enough in theory, but this script will also update the destination every
            // frame as the destination is used for debugging and may be used for other things by other
            // scripts as well. So it makes sense that it is up to date every frame.
            if (ai != null) ai.onSearchPath += Update;
        }

        void OnDisable()
        {
            if (ai != null) ai.onSearchPath -= Update;
        }

        /// <summary>Updates the AI's destination every frame</summary>
        void Update()
        {

            this.ai.maxSpeed = velocity;
            float distancia = Vector3.Distance(target.position, this.transform.position);

            if (this.transform.position.x.ToString("00") == ruta[indiceRuta].position.x.ToString("00") && this.transform.position.y.ToString("00") == ruta[indiceRuta].position.y.ToString("00"))
            {
                if (indiceRuta < ruta.Length - 1)
                {
                    indiceRuta++;

                }
                else if (indiceRuta == ruta.Length - 1)
                {
                    indiceRuta = 0;

                }
            }
            if (distancia <= 3)
            {
                detectado = true;
            }

            MovimientoEnemigo(detectado);
            //rotarEnemigo();
        }

        void MovimientoEnemigo(bool esDetectado)
        {
            if (detectado)
            {
                ai.destination = target.position;
                objetivo = target;
            }
            else
            {
                ai.destination = ruta[indiceRuta].position;
                objetivo = ruta[indiceRuta];
            }
            ani.SetFloat("MovX", (objetivo.position.x - this.transform.position.x));
            ani.SetFloat("MovY", (objetivo.position.y - this.transform.position.y));
        }


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Espada")
            {
                Vector2 diferencia = this.transform.position - collision.transform.position;
                rigidbody2.AddForce(new Vector2(transform.position.x + diferencia.x * 3000, transform.position.y + diferencia.y * 3000));
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.CompareTag("Player"))
            {
                Vector2 diferencia = this.transform.position - collision.transform.position;
                rigidbody2.AddForce(new Vector2(transform.position.x + diferencia.x * 3000, transform.position.y + diferencia.y * 3000));
            }
        }

    }
}
