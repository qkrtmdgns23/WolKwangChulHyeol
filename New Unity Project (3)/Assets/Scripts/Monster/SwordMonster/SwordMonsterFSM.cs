using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordMonsterFSM : MonsterBase
{
    public enum State
    {
        Idle,
        Move,
        Attack,
    };

    public State currentState = State.Idle;

    WaitForSeconds Delay500 = new WaitForSeconds(0.5f);
    WaitForSeconds Delay250 = new WaitForSeconds(0.25f);

    protected void Start()
    {
        base.Start();
        parentRoom = transform.parent.transform.parent.gameObject;
        Debug.Log("Start - State :" + currentState.ToString());

        StartCoroutine(FSM());
    }
    protected virtual void InitMonster() { }

    protected virtual IEnumerator FSM()
    {
        yield return null;

        while (distance > 10)
        {
            yield return Delay500;
        }

        InitMonster();

        while (true)
        {
            yield return StartCoroutine(currentState.ToString());
        }
    }

    protected virtual IEnumerator Idle()
    {
        yield return null;
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("idle"))
        {
            animator.SetTrigger("Idle");
        }

        if (CanAtkStateFun())
        {
            if (canAtk)
            {
                currentState = State.Attack;
            }
            else
            {
                currentState = State.Idle;
                transform.LookAt(player.transform.position);
            }
        }
        else
        {
            currentState = State.Move;
        }
    }

    protected virtual void AtkEffect() { }

    protected virtual IEnumerator Attack()
    {
        yield return null;
        //Atk

        nvAgent.stoppingDistance = 0f;
        nvAgent.isStopped = true;
        nvAgent.SetDestination(player.transform.position);
        yield return Delay500;

        nvAgent.isStopped = false;
        nvAgent.speed = 30f;
        canAtk = false;

        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("stun"))
        {
            animator.SetTrigger("Attack");
        }
        AtkEffect();
        yield return Delay500;

        nvAgent.speed = moveSpeed;
        nvAgent.stoppingDistance = attackRange;
        currentState = State.Idle;
    }

    protected virtual IEnumerator Move()
    {
        yield return null;
        //Move
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("walk"))
        {
            animator.SetTrigger("Walk");
        }
        if (CanAtkStateFun() && canAtk)
        {
            currentState = State.Attack;
        }
        else if (distance > playerRealizeRange)
        {
            nvAgent.SetDestination(transform.parent.position - Vector3.forward * 5f);
        }
        else
        {
            nvAgent.SetDestination(player.transform.position);
        }
    }
}