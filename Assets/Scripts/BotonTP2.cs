using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BotonTP2 : LevelLoader, IInteractable2
{
    //public Transform player;
    //public Transform Almacen;

    public string getDescription()
    {
        return "Entrar al almacén.";
    }

    public void interact()
    {
        // player.transform.position = Almacen.transform.position;
        Debug.Log("Boton Pulsado");
        LoadNextLevel();

    }
}
