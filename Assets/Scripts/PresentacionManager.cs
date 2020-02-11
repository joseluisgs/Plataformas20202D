using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Para manejar escenas
using UnityEngine.SceneManagement;

public class PresentacionManager : MonoBehaviour
{

    public AudioClip sonidoStart;
    public AudioClip sonidoBoton;
    private AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        // Cargamos el Audio Source
        this.audioSource = this.GetComponent<AudioSource>();
    }

    // Evento de botón start
    public void BotonStart()
    {
        // Sonido
        this.audioSource.PlayOneShot(this.sonidoStart);

        // Le decimos a que escena queremos ir
        SceneManager.LoadScene("Juego");
    }

    // Evento de botón Volver
    public void BotonVolver()
    {
        // Sonido
        this.audioSource.PlayOneShot(this.sonidoBoton);

        // Le decimos a que escena queremos ir
        SceneManager.LoadScene("Presentacion");
    }

    // Evento de botón AcercaDe
    public void BotonAcercaDe()
    {

        // Sonido
        this.audioSource.PlayOneShot(this.sonidoBoton);

        // Le decimos a que escena queremos ir
        SceneManager.LoadScene("AcercaDe");
    }
}
