using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlacaPresion : MonoBehaviour
{
    //Referencias al yunque, collider, plataforma y placa de presión
    public GameObject destruirYunque;
    public GameObject destruirCollider;
    public GameObject plataforma;
    public GameObject presion;

    private void OnTriggerEnter(Collider other)
    {
        //Si el objeto que entra en el trigger es un player
        if (other.gameObject.CompareTag("Player"))
        {
            plataforma.SetActive(false); //Desactiva la plataforma

            Invoke("audioYunque", 1.1f); //Reproduce el sonido

            Invoke("destruirYunqueCollider", 1.5f); //Destruye el collider del yunque

            Invoke("destruirYunqueMethod", 5f); //Destruye el yunque
        }
    }

    public void destruirYunqueMethod()
    {
        Destroy(destruirYunque);
    }

    public void destruirYunqueCollider()
    {
        destruirCollider.GetComponent<BoxCollider>().isTrigger = false;
    }

    public void audioYunque()
    {
        gameObject.GetComponent<AudioSource>().Play();
        Invoke("romperAudioYunque", 1.1f);
    }

    public void romperAudioYunque()
    {
        gameObject.GetComponent<AudioSource>().mute = true;
    }

}
