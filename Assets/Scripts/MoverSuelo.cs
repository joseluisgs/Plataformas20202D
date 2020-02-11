using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverSuelo : MonoBehaviour
{
    public float tamaño; // Tamaño del suelo para replicarlo
    public float velocidad;
    public Renderer rend;

    // Podríamos hacerlo como público y arrastrala en propiedades
    private Camera camara;

    // Start is called before the first frame update
    void Start()
    {
        // Si solo hay una cámara de esta manera obtenemos la cámara principal
        camara = Camera.main;

        // Versión con gráficos
        rend = this.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        /* Codigo antioguo 
        // Calculamos la distancia vectorial entre la cára y el suelo
        Vector3 distancia = this.camara.transform.position - this.transform.position;
        // Magnitude te devuelve la longitud del vector.
        // Si el tamaño del suelo es menor que la distancia
        if (this.tamaño <=(distancia).magnitude)
        {
            // Movemos el suelo a la posición x de la cámara
            this.transform.position = new Vector3(this.camara.transform.position.x, this.transform.position.y, this.transform.position.z);
        }
        */

        // Calculamos el desfase. Time.time es el tiempo que ha pasado desde que la app comenzó
        float offset = Time.time * this.velocidad;
        // Cojemos el material, como solo tiene 1, no usamos materials, que es un vector
        this.rend.material.SetTextureOffset("_MainTex", new Vector2(offset, 0.0f));

    }
}
