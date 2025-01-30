using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using static Unity.VisualScripting.Member;
using TMPro;
using static System.TimeZoneInfo;

public class BotonPuertaObstaculo : MonoBehaviour, IInteractable2
{
    //Las puertas, al ser dobles, necesitan referencia a cada una de las dos puertas.
    public GameObject PuertaParaAbrirDer;
    public GameObject PuertaParaAbrirIzq;

    //Referencia al sonido y a la interfaz
    public GameObject sonidoPuerta;
    public GameObject textoUIPuerta;

    //Texto que vemos en la UI al mirar al botón
    public string getDescription()
    {
        return "Abrir Puerta";
    }

    public void interact()
    {
        //Imprimimos por consola que el botón se ha pulsado
        Debug.Log("Boton Puerta Obstaculo pulsado");
        sonidoPuerta.GetComponent<AudioSource>().Play(); //Suena la puerta abriéndose
        Invoke("desactivarSoundPuerta", 2f); //Desactivamos el sonido de la puerta para que no vuelva a sonar si se pulsa el botón de nuevo.

        //Mostramos el texto por pantalla
        ImprimirTextoPuerta();
        Invoke("DesImprimirTextoPuerta", 3.5f);

        //Movemos la puerta
        PuertaParaAbrirDer.transform.Translate(Vector3.down * 1000 * Time.deltaTime);
        PuertaParaAbrirIzq.transform.Translate(Vector3.down * 1000 * Time.deltaTime);
    }

    public void ImprimirTextoPuerta()
    {
        textoUIPuerta.gameObject.SetActive(true);
    }

    public void DesImprimirTextoPuerta()
    {
        textoUIPuerta.gameObject.SetActive(false);
    }

    public void desactivarSoundPuerta()
    {
        sonidoPuerta.SetActive(false);
    }
}