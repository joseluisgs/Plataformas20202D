using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverCamara : MonoBehaviour
{
    public float velocidad = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Movemos la camara hacia la derecha, también podríamos hacer que siga al personaje
        // si este teviese un movimiento autoático, pero no es el caso de este juego
        this.transform.Translate(new Vector3(this.velocidad, 0.0f));
    }
}
