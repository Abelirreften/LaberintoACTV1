using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State<EnemyController>
{
    //Al entrar en estado de ataque lo anuncia por consola
    public override void onEnterState(EnemyController controller)
    {
        base.onEnterState(controller);

        Debug.Log("Robot en estado de Ataque");
    }

    public override void onUpdateState()
    {
        //Si la distancia al jugador es menor que 2m, daña al jugador
        if (Vector3.Distance(transform.position, controller.Player.transform.position) < 2)
        {
            Debug.Log("Enemigo toca jugador");
            FindObjectOfType<HealthManager>().TakeDamage(1);
        }
        else { 
            //Sino, vuelve al estado de patrulla
            controller.ChangeState(controller.ChaseState);
        }
    }

    public override void onExitState()
    {

    }
}
