using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaserPlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Si el objeto que entra en el trigger es un player, le resta 50 de vida
        if (other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<HealthManager>().TakeDamage(50);
        }
    }
}
