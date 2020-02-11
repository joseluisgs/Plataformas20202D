using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    // Obtenemos los materailes de las olas, al ser dos, como array
    public Renderer[] olas;
    public float[] velocidadOla;

    // Para los fondos
    public GameObject[] fondos;
    public float[] velocidadFondo;
    public float[] tamañoFondo;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        this.moverOlas();
        this.moverFondos();
    }

    private void moverOlas()
    {
        for (int i = 0; i < this.olas.Length; i++)
        {
            // Time.time, tiempo desde arrancó la aplicación
            // Es porque es una asignación de ese tiempo
            // Lo calculamos con la app no frame a frame, ver deltatime
            float offset = Time.time * this.velocidadOla[i];
            // Cojemos el material, como solo tiene 1, no usamos materials, que es un vector
            this.olas[i].material.SetTextureOffset("_MainTex", new Vector2(offset, 0.0f));
        }
    }

    private void moverFondos()
    {
        for (int i = 0; i < this.fondos.Length; i++)
        {
            // Preguntamos la distancia de desplazamiento para saber cómo mover (abs porqe se mueve a la izquierda que es negativo)
            // La posición local respecto al padre
            if(Math.Abs(this.fondos[i].transform.transform.localPosition.x) > this.tamañoFondo[i])
            {
                // Regresa el fondo a su posición original
                this.fondos[i].transform.localPosition = new Vector3(0.0f, this.fondos[i].transform.localPosition.y, this.fondos[i].transform.localPosition.z);
            }
            else
            {
                // Si estamos moviendo el fondo
                // Deltatime lo usamos en vez de time
                // Tiempo que ha pasado desde el último frame. Sumamos tiemp frame a frame
                float offset = Time.deltaTime * this.velocidadFondo[i];
                this.fondos[i].transform.localPosition += new Vector3(offset, 0.0f);
            }
        }
    }
}
