using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    //Referencias al punto de spawn de los proyectiles y al prefab del proyectil
    private bool isRunning = true;
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;

    //Velocidad del proyectil
    public float bulletSpeed = 10;

    private void Start()
    {
        //Al comenzar el juego comienza la corrutina de lanzar aviones
        StartCoroutine(lanzarAvion());
    }

    IEnumerator lanzarAvion()
    {
        //Bucle para que lance aviones cada 2 segundos
        while (isRunning)
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletPrefab.transform.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;

            yield return new WaitForSeconds(2f);
        }
    }

    //Método para parar el bucle en caso de necesitarlo
    public void StopLoop()
    {
        isRunning = false;
    }
}