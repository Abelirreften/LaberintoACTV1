using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirarJugador : MonoBehaviour
{
    //Especificamos el Game Object que actúa como jugador
    [Header("Seleccionar Jugador:")]
    public Transform jugador;       // Referencia al Transform del jugador

    void Update()
    {
        //El objeto mira hacia el jugador
        transform.LookAt(jugador);
    }
}
