using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordMonsterFSM : MonsterBase
{
    protected enum State
    {
        Idle,
        Move,
        Attack,
        OnHit
    };

    protected State currentState = State.Idle;

    protected WaitForSeconds Delay500 = new WaitForSeconds(0.5f);
    protected virtual IEnumerator FSM()
    {
        yield return null;

        

        while (true)
        {
            if (!_isDeath)
            {
                nvAgent.isStopped = true;
                nvAgent.speed = 0;
                break;
            }
            if (distance > playerRealizeRange)
            {
                StartCoroutine(Idle());
                nvAgent.SetDestination(this.transform.position);
                yield return Delay500;
            }
            else
            {
                yield return StartCoroutine(currentState.ToString());
            }
        }
    }
    protected virtual IEnumerator Idle()
    {
        yield return null;
        if (!_isknockback)
        {
            if (!monsterAnimator.GetCurrentAnimatorStateInfo(0).IsName("Sword And Shield Idle"))
            {
                monsterAnimator.SetTrigger("Idle");
            }

            if (CanAtkState())
            {
                if (canAtk)
                {
                    currentState = State.Attack;
                }
                else
                {
                    currentState = State.Idle;
                }
            }
            else
            {
                currentState = State.Move;
            }
        }
        else
        {
            currentState = State.OnHit;
        }
        
    }
    protected virtual IEnumerator Move()
    {
        yield return null;
        //Move
        if (!_isknockback)
        {
            if (!monsterAnimator.GetCurrentAnimatorStateInfo(0).IsName("Sword And Shield Walk"))
            {
                monsterAnimator.SetTrigger("Walk");
            }

            if (CanAtkState())
            {
                currentState = State.Attack;
            }
            else if (distance > playerRealizeRange)
            {
                currentState = State.Idle;
            }
            else if (monsterAnimator.GetCurrentAnimatorStateInfo(0).IsName("Sword And Shield Walk"))
            {
                nvAgent.SetDestination(player.transform.position);
            }
        }
        else
        {
            currentState = State.OnHit;
        }
    }

    protected virtual IEnumerator Attack()
    {
        yield return null;
        //Atk
        if (!_isknockback)
        {

            nvAgent.isStopped = true;
            nvAgent.SetDestination(this.transform.position);
            yield return Delay500;


            monsterAnimator.SetTrigger("Attack");
            yield return Delay500;

            if (CanAtkState())
            {
                currentState = State.Attack;
            }
            else
            {

                currentState = State.Idle;
            }
        }
        else
        {
            currentState = State.OnHit;
        }
    }

    protected IEnumerator OnHit()
    {
        yield return null;

        int playerdamage = 10; //수정 필요
      
      
       
        
        if (!monsterAnimator.GetCurrentAnimatorStateInfo(0).IsName("Sword1h_Hit_Head_Front"))
        {
            stats.hp -= playerdamage;
            if (0 <=stats.hp)
            { 
                Debug.Log(stats.hp);
                nvAgent.isStopped = true;
                rigid.AddForce(-direction * playerdamage*10, ForceMode.VelocityChange);
                monsterAnimator.SetBool("Knockback", true);
                monsterAnimator.SetTrigger("MonsterPushback");
            }
        }

        yield return Delay3000;
        Debug.Log("쑥");
        monsterAnimator.SetBool("Knockback", false);
        _isknockback = false;
        nvAgent.speed = moveSpeed;
        nvAgent.stoppingDistance = attackRange;
        currentState = State.Idle;
        nvAgent.isStopped = false;

    }

}

//    

//    WaitForSeconds Delay500 = new WaitForSeconds(0.5f);
//    WaitForSeconds Delay250 = new WaitForSeconds(0.25f);

//    protected void Start()
//    {
//        base.Start();
//        Debug.Log("Start - State :" + currentState.ToString());

//        StartCoroutine(FSM());
//    }
//    protected virtual void InitMonster() { }

//    protected virtual IEnumerator FSM()
//    {
//        yield return null;

//        while (distance > 10)
//        {
//            yield return Delay500;
//        }

//        InitMonster();

//        while (true)
//        {
//            yield return StartCoroutine(currentState.ToString());
//        }
//    }

//    protected virtual IEnumerator Idle()
//    {
//        yield return null;
//        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("idle"))
//        {
//            animator.SetTrigger("Idle");
//        }
//        if (CanAtkStateFun())
//        {
//            if (canAtk)
//            {
//                currentState = State.Attack;
//            }
//            else
//            {
//                currentState = State.Idle;
//                transform.LookAt(player.transform.position);
//            }
//        }
//        else
//        {
//            currentState = State.Move;
//        }
//    }

//    protected virtual void AtkEffect() { }

//    protected virtual IEnumerator Attack()
//    {
//        yield return null;
//        //Atk

//        nvAgent.stoppingDistance = 0f;
//        nvAgent.isStopped = true;
//        
//        yield return Delay500;

//        nvAgent.isStopped = false;
//        nvAgent.speed = 30f;
//        canAtk = false;

//        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("stun"))
//        {
//            animator.SetTrigger("Attack");
//        }
//        AtkEffect();
//        yield return Delay500;

//        nvAgent.speed = moveSpeed;
//        nvAgent.stoppingDistance = attackRange;
//        currentState = State.Idle;
//    }

//    protected virtual IEnumerator Move()
//    {
//        yield return null;
//        //Move
//        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("walk"))
//        {
//            animator.SetTrigger("Walk");
//        }
//        if (CanAtkStateFun() && canAtk)
//        {
//            currentState = State.Attack;
//        }
//        else if (distance > playerRealizeRange)
//        {
//            //nvAgent.SetDestination(transform.parent.position - Vector3.forward * 5f);
//            nvAgent.SetDestination(this.transform.position);
//        }
//        else
//        {
//            nvAgent.SetDestination(player.transform.position);
//        }
//    }
//}