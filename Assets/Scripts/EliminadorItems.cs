using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliminadorItems : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Detectamos si hemos colisionado
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Comparamos si colisinamos con objetos de etiqueta Moneda
        //if (collision.gameObject.CompareTag("Moneda"))
        //{
        //Debug.Log("Eliminador: " + col.gameObject.tag);
        // Primero desactivamos ese objeto que ha colisionado con nostros
        collision.gameObject.SetActive(false);
        // Luego lo destruimos
        Destroy(collision.gameObject, 0.5f);
        //}
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Si tocamos la plataforma la desactivaos
        collision.gameObject.SetActive(false);
        // Luego lo destruimos
        Destroy(collision.gameObject, 0.25f);
    }
}
