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

    protected Vector3 direction;
    protected bool _isDeath = true;
    protected bool _isknockback = false;
    protected bool canAtk = false;
    protected float distance;
    protected float playerRealizeRange = 10f;
    protected float attackRange = 2f;
    protected float moveSpeed = 2.0f;
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
        if (stats.hp < 0 && _isDeath)
        {
            _isDeath = false;
            Death();
        }
        if (_isDeath)
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
            Vector3 targetPosition = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
            transform.LookAt(targetPosition);
            //animator.SetTrigger("_turn");
        }
    }

}


//    public float maxHp = 1000f;
//    public float currentHp = 1000f;

//    public float damage = 100f;

//   
//    
//    protected float attackCoolTime = 5f;
//    protected float attackCoolTimeCacl = 5f;
//    protected bool discoveryPlayer = false;

//    protected float moveSpeed = 2f;

//    protected GameObject player;

//    protected GameObject parentRoom;

//    protected Animator animator;
//    protected Rigidbody monsterRigid;


//    // Use this for initialization
//    protected void Start()
//    {
//        player = GameObject.FindGameObjectWithTag("Player");
//        nvAgent = GetComponent<NavMeshAgent>();

//        monsterRigid = GetComponent<Rigidbody>();
//        animator = GetComponent<Animator>();
//        SearchPlayer();
//    }
//    protected bool SearchPlayer()
//    {

//        return true;
//    }


//}