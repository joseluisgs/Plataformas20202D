using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliminadorEnemigos : MonoBehaviour
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
    void OnCollisionEnter2D(Collision2D col)
    {
        // Comparamos si colisinamos con objetos de etiqueta Enemigo
        if (col.gameObject.CompareTag("Enemigo"))
        {
            //Debug.Log("Eliminador: " + col.gameObject.tag);
            // Primero desactivamos ese objeto que ha colisionado con nostros
            col.gameObject.SetActive(false);
            // Luego lo destruimos
            Destroy(col.gameObject, 0.5f);
        }
    }
}
