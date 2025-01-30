using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    //Referencias al laser, audio source y bool
    private bool isRunning = true;
    public GameObject laser;
    public GameObject audioSource;

    private void Start()
    {
        //Al comenzar el juego se activa la corrutina
        StartCoroutine(ActivarLaser());
    }

    IEnumerator ActivarLaser()
    {
        while (isRunning)
        {

            //Se activa el laser y suena
            laser.SetActive(true);
            audioSource.GetComponent<AudioSource>().Play();

            yield return new WaitForSeconds(3f); //Espera 3s

            //Se desactiva el laser
            laser.SetActive(false);

            yield return new WaitForSeconds(3f); //Espera 3s
        }
    }

    //Método para parar el bucle en caso de necesitarlo
    public void StopLoop()
    {
        isRunning = false;
    }
}
