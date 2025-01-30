using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YunqueDañoPlataforma : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Si el objeto que entra en el trigger es un player
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Yunque toca Jugador");
            FindObjectOfType<HealthManager>().TakeDamage(90); //Resta al player 90 de vida
        }
        //Si el objeto que entra en el trigger es un enemy
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Yunque toca Enemy");
            other.gameObject.SetActive(false); //Destruye al enemy y desaparece

        }
    }
}
