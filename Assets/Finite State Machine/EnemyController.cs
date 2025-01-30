using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : Controller
{
    //Referencias al estado, waypoints, player y distintos estados
    private State<EnemyController> currentState;

    public Transform[] waypoints;
    int waypointIndex;
    Vector3 target;

    private GameObject player;
    public GameObject robot;

    private PatrolState patrolState;
    private ChaseState chaseState;
    private AttackState attackState;

    private NavMeshAgent agent;

    public AudioSource audioSourceRobot;
    public AudioSource audioSourceSFX;

    //Getters y Setters
    #region Getters y Setters
    public NavMeshAgent Agent { get => agent; }
    public GameObject Player { get => player; }

    public Vector3 Target { get => target; set => target = value; }
    public PatrolState PatrolState { get => patrolState; }
    public ChaseState ChaseState { get => chaseState; }
    public AttackState AttackState { get => attackState; }
    #endregion

    private void Awake()
    {
        //Inicializamos variables importantes y asignamos estado inicial
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindObjectOfType<PlayerController>().gameObject;

        patrolState = GetComponent<PatrolState>();
        chaseState = GetComponent<ChaseState>();
        attackState = GetComponent<AttackState>();

        ChangeState(patrolState);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState != null)
        {
            currentState.onUpdateState();
        }
    }

    //Método para cambiar de estado
    public void ChangeState(State<EnemyController> newState)
    {
        if (currentState != null)
        {
            currentState.onExitState();
        }
        currentState = newState; // Mi estado actual pasa a ser el nuevo
        currentState.onEnterState(this);
    }

    //Método para actualizar el target al siguiente waypoint
    public void updateDestination()
    {
        target = waypoints[waypointIndex].position;

        Agent.SetDestination(target);
    }

    //Método para asignar el siguiente waypoint de la lista de waypoints
    public void iterateWaypointIndex()
    {
        waypointIndex++;
        if (waypointIndex >= waypoints.Length)
        {
            waypointIndex = 0;
        }
    }
}
