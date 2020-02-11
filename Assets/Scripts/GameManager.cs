using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Para accader a elementos de la IU
using UnityEngine.UI;
// Para manejar escenas
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text vidas;
    public Text monedas;
    public Text puntuacion;
    public Text record;

    public Personaje personaje;

    public GameObject gameOver;

    // Sonidos
    public AudioClip sonidoStart;
    public AudioClip sonidoRestart;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        // Ocultamos game over
        this.gameOver.SetActive(false);

        // Cargamos el Audio Source
        this.audioSource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        this.vidas.text = "X " + this.personaje.vidas.ToString();
        this.monedas.text = this.personaje.monedas.ToString() + " X";

        // Si hemos muerto, nos activamos y no hemos activado la pantalla
        if (this.personaje.vidas <= 0 && !this.gameOver.activeSelf)
        {
            this.gameOver.SetActive(true);
            // Ponemos record y puntuacion
            this.record.text = PlayerPrefs.GetInt("Monedas").ToString();
            this.puntuacion.text = this.personaje.monedas.ToString();
        }

    }

    // Evento de botón restart
    public void BotonRestart()
    {
        // Sonido
        this.audioSource.PlayOneShot(this.sonidoRestart);

        // Le decimos a que escena queremos ir
        SceneManager.LoadScene("Juego");
    }

    // Evento de botón restart
    public void BotonStart()
    {
        // Sonido
        this.audioSource.PlayOneShot(this.sonidoStart);

        // Le decimos a que escena queremos ir
        SceneManager.LoadScene("Presentacion");
    }
}
