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
        OnHit,
        Block
    };

    protected State currentState = State.Idle;
    protected int attackPercentage;
    protected WaitForSeconds Delay500 = new WaitForSeconds(0.5f);
    protected WaitForSeconds Delay250 = new WaitForSeconds(0.25f);
    private int monsterWaypointCount = 0;
    protected virtual IEnumerator FSM()
    {
        yield return null;

        

        while (true)
        {
            if (_isDeath)
            {
                nvAgent.isStopped = true;
                nvAgent.speed = 0;
                break;
            }
            if (!_isMonsterReady)
            {
                if (distance > playerRealizeRange)
                {
                    _isMonsterReady = false;

                    if (wayPoint.Point.Length == 0)
                    {
                        StartCoroutine(Idle());
                        nvAgent.SetDestination(this.transform.position);
                        yield return Delay500;
                    }
                    else
                    {
                        wayPointMove();
                        yield return null;
                    }
                }
                else
                {
                    _isMonsterReady = true;
                }
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
                    if (attackPercentage < randomAttack)
                    {
                        currentState = State.Attack;
                    }
                    else
                    {
                        currentState = State.Block;
                    }
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
                if (attackPercentage < randomAttack)
                {
                    currentState = State.Attack;
                }
                else
                {
                    currentState = State.Block;
                }
            }
            else if (distance > playerRealizeRange && !_isMonsterReady)
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

            nvAgent.SetDestination(this.transform.position);
            yield return Delay250;


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

        if (!monsterAnimator.GetCurrentAnimatorStateInfo(0).IsName("Sword1h_Hit_Head_Front"))
        {
            if (0 <=stats.hp)
            { 
                nvAgent.isStopped = true;
                monsterAnimator.SetBool("Knockback", true);
                monsterAnimator.SetTrigger("MonsterPushback");
            }
        }

        yield return Delay3000;
        monsterAnimator.SetBool("Knockback", false);
        _isknockback = false;
        nvAgent.speed = moveSpeed;
        nvAgent.stoppingDistance = attackRange;
        currentState = State.Idle;
        nvAgent.isStopped = false;

    }
    protected virtual IEnumerator Block()
    {
        yield return null;
       
        nvAgent.isStopped = true;
        yield return Delay250;

        _isBlock = true;
        if (!monsterAnimator.GetCurrentAnimatorStateInfo(0).IsName("Sword And Shield Block"))
        {
            monsterAnimator.SetTrigger("Block");
        }
        yield return Delay3000;
        nvAgent.isStopped = false;
        currentState = State.Idle;
        _isBlock = false;
    }
    private void wayPointMove()
    {
        if (!monsterAnimator.GetCurrentAnimatorStateInfo(0).IsName("Sword And Shield Walk"))
        {
            monsterAnimator.SetTrigger("WayPoint");
        }

        if (monsterWaypointCount != wayPoint.Point.Length)
        {
            if (Vector3.Distance(this.transform.position, wayPoint.Point[monsterWaypointCount].position) > 2)
            {
                nvAgent.SetDestination(wayPoint.Point[monsterWaypointCount].position);
                Vector3 targetDirection = (wayPoint.Point[monsterWaypointCount].position - this.transform.position).normalized;
                this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.LookRotation(targetDirection), Time.deltaTime * 5);
            }
            else
            {
                monsterWaypointCount++;
            }
        }
        else
        {
            monsterWaypointCount = 0;
        }
       
    }
}

//    

//    WaitForSeconds Delay500 = new WaitForSeconds(0.5f);
//    

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