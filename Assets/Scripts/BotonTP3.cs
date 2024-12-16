using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BotonTP3 : LevelLoader, IInteractable2
{
    //Texto que vemos en la UI
    public string getDescription()
    {
        return "Salir del almacén.";
    }

    public void interact()
    {
        //Imprimimos por consola que el botón se ha pulsado
        Debug.Log("Boton Pulsado Salida");

        //Lamamos a la función para cargar el siguiente nivel
        LoadNextLevel();

    }
}