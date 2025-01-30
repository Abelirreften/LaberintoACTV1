using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State<EnemyController>
{
    //Al entrar en estado de Perseguir, lo anuncia por consola.
    public override void onEnterState(EnemyController controller)
    {
        base.onEnterState(controller);

        Debug.Log("Robot en estado de Perseguir");
    }

    public override void onUpdateState()
    {
        //Si el jugador está a menos de 4m le persigue
        if (Vector3.Distance(transform.position, controller.Player.transform.position) < 4)
        {
            controller.Agent.SetDestination(controller.Player.transform.position);
        }
        else
        {
            //Sino, vuelve al estado de patrulla
            controller.ChangeState(controller.PatrolState);

        }
        //Si el jugador está a menos de 2m, entra en estado de ataque
        if (Vector3.Distance(transform.position, controller.Player.transform.position) < 2)
        {
            controller.ChangeState(controller.AttackState);
        }
    }

    public override void onExitState()
    {
        
    }
}
