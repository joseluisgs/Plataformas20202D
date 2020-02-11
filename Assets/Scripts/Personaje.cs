using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    // Variables de control de personaje
    private bool saltando;
    private bool atacando;
    // Lo que definamos como públicas las podemos cambiar en el editor
    public int vidas;
    public int monedas;

    public GameObject ataque;
    public GameObject posicionAtaque;

    public float velocidad = 0.2f;
    public float salto = 300.0f;

    public Animator animator;
 

    // Movimientos
    private bool moviendoDerecha;
    private bool moviendoIzquierda;

    // Sonido
    public AudioClip sonidoSalto;
    public AudioClip sonidoDaño;
    public AudioClip sonidoMuerte;
    public AudioClip sonidoMoneda;
    private AudioSource audioSource;



    // Start is called before the first frame update
    void Start()
    {
        // Podemos indicrlo aquí o en el editor
        //this.vidas = 3;
        this.monedas = 0;
        this.saltando = false;
        this.atacando = false;
        // Para saber el tamaño de la pantalla
        //Debug.Log("Screen Width : " + Screen.width);

        // Cargamos el Audio Source
        this.audioSource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Vamos a analizar el movimiento del personaje
        //Input.GetKeyDown -> Solo cuando lo pulsas
        //Input.GetKey --> Incluso si lo dejas pulsado
        // Con GetComponent obtenemos uno de los componentes que tengamos

        // Si pulsamos ir a la izquierda o con los botones de la interfaz variable cerrojo
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || this.moviendoIzquierda)
        {
            // Indicamos cuanto queremos que se mueva, no donde..., eje X
            transform.Translate(new Vector3(-this.velocidad, 0.0f));
        }
        //Si voy a la izquierda no puedo ir a la derecha y viceversa
        else
        // Si pulsamos ir a la derecha, o con los botones de la interfaz variable cerrojo
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || this.moviendoDerecha)
        {
            // Indicamos cuanto queremos que se mueva, no donde... eje X
            transform.Translate(new Vector3(this.velocidad, 0.0f));
        }

        // Si queremos saltar
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            // saltamos, refactorizado a método propio para eventos de botones
            this.saltar();
        }

        // Si atacamos
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Atacamos, refactorizado a métido propio para botones
            this.atacar();
        }

    }

    private void terminarAtaque()
    {
        this.atacando = false;
    }


    // Nos detecta como actuar si hay colisión y choca una vez
    // Este método se llama cuando colisione con algo por primera vez, por eso filtramos con la etiqueta
    void OnCollisionEnter2D(Collision2D col)
    {
        // Comparamos si colisinamos con objetos con etiqueta Suelo
        if (col.gameObject.CompareTag("Suelo"))
        {
            this.saltando = false;
            // Animación
            this.animator.SetBool("Saltando", this.saltando);
        }

        // Si chocamos con un enemigo, lo quitamos y disminuye nuestra vida.
        if (col.gameObject.CompareTag("Enemigo"))
        {

            // Sonido
            this.audioSource.PlayOneShot(this.sonidoDaño);
            col.gameObject.SetActive(false);
            Destroy(col.gameObject, 1.0f);
            this.vidas--;
            // animación
            this.animator.SetTrigger("Daño");
            Debug.Log("Vidas: " + this.vidas);
            // Si nos quedamos sin vidas
            // Cuando muedo
            if (this.vidas <= 0)
            {
                // Sonido
                this.audioSource.PlayOneShot(this.sonidoMuerte);
                Debug.Log("El jugador ha muerto");

                Invoke("descativarPersonaje", 2.5f);
                // Animación
                this.animator.SetBool("Morir", true);
                // Comprobamos el record
                this.comprobarRecord();
            }
        }

       
    }

    // DEsactiva el personaje en X segundos
    private void descativarPersonaje()
    {
        this.gameObject.SetActive(false);
        Destroy(this.gameObject, 0.5f);
    }



    // Para los eventos de colisiones Triger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Si es una moneda
        if (collision.gameObject.CompareTag("Moneda"))
        {
            // Sonido
            this.audioSource.PlayOneShot(this.sonidoMoneda);
            // Nos cargamos la moneda
            collision.gameObject.SetActive(false);
            Destroy(collision.gameObject, 0.5f);
            // Aumentamos las monedas
            monedas++;
            Debug.Log("Monedas: " + this.monedas);
        }
    }

    // Comprueba le record y lo guarda
    private void comprobarRecord()
    {
        // PlayerPrefs nos deja guardar preferencias o datos en modo clave valor
        // Podríamos guardar estadísticas y recuperarlas
        int recordUltimo = PlayerPrefs.GetInt("Monedas");
        if (PlayerPrefs.HasKey("Monedas") == false)
        {
            //No hay record guardado
            PlayerPrefs.SetInt("Monedas", monedas);
        }
        else
        {
            //Si hay record guardado
            if (recordUltimo < monedas)
            {
                PlayerPrefs.SetInt("Monedas", monedas);
                Debug.Log("NUEVO RECORD! " + monedas);
            }
        }
    }

    // Función de saltar, publicas para los eventos de botones y para control teclado
    public void saltar()
    {
        //Saltar. Cogemos el RigidBody con GetComponet (fisica asocaciada al objeto, y le aplicamos una fuerza en eje Y)
        //Depende de la masa y de la gravedad
        // Solo podemos saltar si no estamos saltando, para evitar múltiples saltos a la vez (en el aire)
        if (this.saltando == false)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, this.salto));
            // estoy saltando
            this.saltando = true;
            // Animación
            this.animator.SetBool("Saltando", this.saltando);
            // Sonido
            //this.audioSource.clip = this.sonidoSalto;
            //this.audioSource.Play();
            this.audioSource.PlayOneShot(this.sonidoSalto);
        }
    }

    // Función para atacar con eventos de botones y teclado
    public void atacar()
    {
        // Si no estamos atacando ya (para no pulsar contínuamente)
        if (this.atacando == false)
        {
            // Creamos el ataque en la posición de ataque.
            GameObject.Instantiate(this.ataque, this.posicionAtaque.transform.position, this.posicionAtaque.transform.rotation);
            // Indicamos que estamos atacando
            this.atacando = true;
            // animación
            this.animator.SetTrigger("Atacando");
            // Para llamar a este método pero con un retraso
            Invoke("terminarAtaque", 0.5f);
        }
    }

    // Cerrojo de movimiento derecha
    public void moverDerecha(bool activar)
    {
        this.moviendoDerecha = activar;
    }

    // Cerrojo de movimiento izquierda
    public void moverIzquierda(bool activar)
    {
        this.moviendoIzquierda = activar;
    }
}
