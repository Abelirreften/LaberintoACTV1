using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : State<EnemyController>
{
    //Al comenzar el juego el robot está en estado de patrulla
    public override void onEnterState(EnemyController controller)
    {
        base.onEnterState(controller);
        Debug.Log("Robot en estado de Patrulla");

        controller.updateDestination();
    }

    public override void onUpdateState()
    {
        //Detecta si ha llegado al waypoint
        if (Vector3.Distance(transform.position, controller.Target) < 2)
        {
            controller.audioSourceSFX.GetComponent<AudioSource>().Play();
            controller.iterateWaypointIndex();
            controller.updateDestination();
        }

        if (Vector3.Distance(transform.position, controller.Player.transform.position) < 4)
        {
            //Si el jugador está dentro de su rango de detección, cambia al estado de Perseguir
            controller.audioSourceRobot.GetComponent<AudioSource>().Play();
            controller.ChangeState(controller.ChaseState);
        }
    }

    public override void onExitState()
    {
        Debug.Log("Saliendo de Patrol");
    }
}
