using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class RaycastPlayer : JumpScare
{
    //Audio Source desde donde suena el audio
    public AudioSource source;
    void Update()
    {
        //Creamos el punto en el que golpea el rayo
        RaycastHit hit;

        //Creamos el rayo hacia delante
        Ray ray = new Ray(transform.position, transform.forward);

        //Coloreamos el rayo para mejor previsualización
        Debug.DrawRay(ray.origin, ray.direction * 2f, Color.green);


        //Detectamos el objeto con el que choca
        if (Physics.Raycast(ray, out hit))
        {
            //Si el objeto tiene tag "Enemigo" suena el audio y se desactiva el objeto
            if (hit.transform.gameObject.CompareTag("Enemigo"))
            {
                source.GetComponent<AudioSource>().Play();
                hit.transform.gameObject.SetActive(false);
            }
        }
    }
}
