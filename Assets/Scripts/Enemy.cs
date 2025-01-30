using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    // SCRIPT REEMPLAZADO POR MÁQUINA DE ESTADOS.

    //Referencias al player, Nav Mesh Agent, waypoints y target
    private GameObject player;

    private NavMeshAgent agent;
    public Transform[] waypoints;
    int waypointIndex;
    Vector3 target;

    private void Awake()
    {
        //Asignamos el agent
        agent = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        //Asignamos el Player y actualizamos destino
        player = GameObject.FindObjectOfType<PlayerController>().gameObject;
        updateDestination();
    }

    void Update()
    {
        //Si la distancia al waypoint < 2 = cambiar target al siguiente waypoint
        if (Vector3.Distance(transform.position, target) < 2)
        {
            iterateWaypointIndex();
            updateDestination();
        }
        //Si la distancia al player < 5 = perseguir al player
        if (Vector3.Distance(transform.position, player.transform.position) < 5)
        {
            agent.SetDestination(player.transform.position);
        }
        else {
            updateDestination();
        }
        //Si distancia al player < 2 = hacer daño al player
        if (Vector3.Distance(transform.position, player.transform.position) < 2)
        {
            Debug.Log("Enemigo toca jugador");
            FindObjectOfType<HealthManager>().TakeDamage(1);
        }
    }

    //Target adquiere el nuevo índice de la lista de waypoints
    void updateDestination()
    {
        target = waypoints[waypointIndex].position;
        agent.SetDestination(target);
    }

    //Aumentar el índice de la lista de waypoints
    void iterateWaypointIndex()
    {
        waypointIndex++;
        if (waypointIndex >= waypoints.Length)
        {
            waypointIndex = 0;
        }
    }
}
