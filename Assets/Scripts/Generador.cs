using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generador : MonoBehaviour
{
    // Objeto a referencia. No olvides arastrarlo desde el prebas al campo en Unity
    public GameObject item;
    public float frecuencia = 1.0f;
    public float xMin=0;
    public float xMax = 0;
    public float yMin=0;
    public float yMax = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        // llamamos al generador
        this.generarItem();


    }

    // Generamos enemigos según un dado
    private void generarItem()
    {
        float rand = Random.Range(0.0f, 100.0f);
        // Si es menor que 1. Recordamos que esta función se llama cada update, es decir cada 24/30 fps
        if (rand < this.frecuencia)
        {
            //Creamos el enemigo en donde le digamos
            Vector2 pos = new Vector2(transform.position.x + Random.Range(xMin, xMax), transform.position.y + Random.Range(yMin, yMax));
            GameObject.Instantiate(this.item, pos, transform.rotation);
            //GameObject.Instantiate(this.item, transform.position, transform.rotation);
        }

    }

   
}
