using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip sonidoEnemigoMuere;
    private AudioSource audioSource;
    // Animacion de enemigo
    //public Animator enemigo;

    void Start()
    {
        // Si no ha venido nadie y no hemos chocado en ese tiempo, nos destruímos
        Destroy(this.gameObject, 0.5f);

        // Cargamos el Audio Source
        this.audioSource = this.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Cuando toque con un enemigo se destruyen ambos
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            // Sonido
            this.audioSource.PlayOneShot(this.sonidoEnemigoMuere);

            // Animacion
            //this.enemigo.SetTrigger("EnemigoMuerto");

            collision.gameObject.SetActive(false);
            Destroy(collision.gameObject, 0.5f);
            this.gameObject.SetActive(false);
            Destroy(this.gameObject, 0.1f);
        }
    }
}
