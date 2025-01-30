using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class avionPapel : MonoBehaviour
{
    //Variables de tiempo de vida del objeto y referencia al prefab
    public float life = 3;
    public GameObject avionTotal;

    private void Awake()
    {
        //El avión desaparece después del tiempo de vida
        //Se destruye tanto el gameObject como el prefab del avión para evitar errores
        Destroy(gameObject, life);
        Destroy(avionTotal, life);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Si el objeto que entra en el trigger es una diana o es un enemigo, el avión desaparece.
        if (other.gameObject.CompareTag("Diana") || other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Destroy(avionTotal);

        } else if (other.gameObject.CompareTag("Player")) //Si el objeto que entra en el trigger es un Player, se resta vida y se destruye el avión
        {
            Debug.Log("Avion toca jugador");
            FindObjectOfType<HealthManager>().TakeDamage(20);
            Invoke("destruirAvion", 0.1f);

        }
    }
    //Método para destruir el avión mediante Invoke
    private void destruirAvion()
    {
        Destroy(gameObject);
        Destroy(avionTotal);
    }
}
