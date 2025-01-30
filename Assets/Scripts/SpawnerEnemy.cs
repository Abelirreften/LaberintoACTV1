using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    //Asignamos el prefab del enemy
    [SerializeField]
    private Enemy enemyPrefab;

    //Al iniciar el juego aparecerá otro enemigo
    void Start()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }
}
