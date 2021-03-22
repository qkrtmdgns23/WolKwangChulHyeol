//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.AI;

//public class MonsterBase : MonoBehaviour
//{
//    public float maxHp = 1000f;
//    public float currentHp = 1000f;

//    public float damage = 100f;

//    protected float playerRealizeRange = 10f;
//    protected float attackRange = 5f;
//    protected float attackCoolTime = 5f;
//    protected float attackCoolTimeCacl = 5f;
//    protected bool discoveryPlayer = false;

//    protected float moveSpeed = 2f;

//    protected GameObject player;
//    protected NavMeshAgent nvAgent;
//    protected float distance;

//    protected GameObject parentRoom;

//    protected Animator animator;
//    protected Rigidbody monsterRigid;

//    public LayerMask layerMask;

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
//    protected bool CanAtkState()
//    {
//        Vector3 targetDir = new Vector3(player.transform.position.x - transform.position.x, 0f, player.transform.position.z - transform.position.z);

//        Physics.Raycast(new Vector3(transform.position.x, 0.5f, transform.position.z), targetDir, out RaycastHit hit, 30f, layerMask);
//        distance = Vector3.Distance(player.transform.position, transform.position);
//        Debug.DrawRay(new Vector3(transform.position.x, 0.5f, transform.position.z), targetDir , Color.red, 0.1f);
        
//        if (hit.transform == null)
//        {
//            Debug.Log(player.name);
//            return false;
//        }

//        if (hit.transform.CompareTag("Player") && distance >= attackRange)
//        {
            
//            return true;
//        }
//        else
//        {
//            return false;
//        }
//    }
    
//}