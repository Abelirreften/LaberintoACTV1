using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JumpScare : MonoBehaviour
{
    //Objeto
    public GameObject jumpscareObjetc;

    //Comprobar si un objeto entra en el collider
    private void OnTriggerEnter(Collider other)
    {
        //Si el objeto que entra es jugador se activa el jumpscare y se destruye el Triggercollider
        if (other.gameObject.CompareTag("Player"))
        {
            jumpscareObjetc.gameObject.SetActive(true);
            Destroy(gameObject);
        }
    }

}