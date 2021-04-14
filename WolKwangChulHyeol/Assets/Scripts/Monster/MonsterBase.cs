using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using CoreStats;


public class MonsterBase : MonoBehaviour
{
    protected CoreStats.Stats stats;
    protected GameObject player;
    protected Animator monsterAnimator;
    protected Collider playerAttack;
    protected NavMeshAgent nvAgent;
    protected Rigidbody rigid;
  
    public LayerMask layerMask;
    public WayPoint wayPoint;
    protected Vector3 direction;
    protected bool _isDeath = false;
    protected bool _isknockback = false;
    protected bool canAtk = false;
    protected bool _isBlock = false;
    protected float distance;
    protected float playerRealizeRange = 10f;
    protected float attackRange = 2.3f;
    protected float moveSpeed = 2.0f;
    protected int playerdamage = 10;
    protected int randomAttack = 0;
    protected bool _isMonsterReady;
    protected WaitForSeconds Delay3000 = new WaitForSeconds(3f);
    public void Start()
    {
        player = GameObject.Find("Player");
        stats = this.GetComponent<CoreStats.Stats>();
        playerAttack = player.transform.Find("attack").GetComponent<BoxCollider>();
        monsterAnimator = this.GetComponent<Animator>();

    }
    protected bool CanAtkState()
    {

        Vector3 targetDir = new Vector3(player.transform.position.x - transform.position.x, 0f, player.transform.position.z - transform.position.z);

        Physics.Raycast(new Vector3(transform.position.x, 0.5f, transform.position.z), targetDir, out RaycastHit hit, 30f, layerMask);

        if (hit.transform == null)
        {
            return false;
        }
        if (hit.transform.CompareTag("Player") && distance <= attackRange)
        {
            if (!_isknockback)
            {
                canAtk = true;
                return true;
            }
            canAtk = false;
            return false;
        }
        else
        {
            return false;
        }
    }
    protected void PlayerScan()
    {

    }

    protected void AnyState()
    {
        if (stats.hp < 0 && !_isDeath)
        {
            _isDeath = true;
            Death();
        }
        if (!_isDeath)
        {
            LookPlayer();
        }
    }
    protected void MonsterPushback()
    {

    }
    private void Death()
    {
        monsterAnimator.SetTrigger("Death");
        //monsterAnimator.SetBool("IsDeath", true);
        nvAgent.isStopped = true;
        nvAgent.speed = 0;
        //nvAgent.SetDestination(this.transform.position);
        Destroy(gameObject, 7);
    }
    private void LookPlayer()
    {

        if (player != null)
        {
           // Vector3 targetPosition = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
            //transform.LookAt(targetPosition);
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * 5);
            //animator.SetTrigger("_turn");
        }
    }

}