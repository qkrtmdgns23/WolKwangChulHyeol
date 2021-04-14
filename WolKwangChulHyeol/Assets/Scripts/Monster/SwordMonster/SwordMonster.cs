using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class SwordMonster : SwordMonsterFSM
{
    MonsterBase monsterBase ;
    
    private void Awake()
    {
       
        monsterBase = this.GetComponent <MonsterBase>();
        monsterAnimator = this.GetComponent<Animator>();
        nvAgent = this.GetComponent<NavMeshAgent>();
        rigid = this.GetComponent<Rigidbody>();


    }
    void Start()
    {
        monsterBase.Start();
        distance = Vector3.Distance(player.transform.position, transform.position);

        stats.hp = 20;
        stats.movespeed = 10;
        attackRange = 2.25f;
        nvAgent.speed = moveSpeed;
        nvAgent.stoppingDistance = attackRange;

        _isDeath = false;
        _isMonsterReady = false;
        _isBlock = false;
        playerdamage = 10; // 변경 예정
        attackPercentage = 50;

        StartCoroutine(FSM());

    }

    private void Update()
    {
        if (_isMonsterReady)
        {
            AnyState();
        }
        
        distance = Vector3.Distance(player.transform.position, transform.position);
        direction = (player.transform.position - this.transform.position).normalized;
        randomAttack = Random.Range(0, 101);

    }
    private void OnTriggerStay(Collider _collider)
    {
        if (!_isDeath)
        {
            if (Input.GetKeyDown(KeyCode.E))//플레이어 어택 참조 예정
            {

                Debug.Log("bbbb");
                if (!_isBlock)
                {
                    if (_collider == playerAttack)
                    {
                        _isMonsterReady = true;
                        //수정 필요
                        stats.hp -= playerdamage;
                        if (!_isknockback)
                        {
                            _isknockback = true;
                        }
                    }
                }
            }

        }
    }
    

}
//    public GameObject enemyCanvasGo;
//    public GameObject meleeAtkArea;

//    void Start()
//    {

//        base.Start();
//        attackCoolTime = 2f;
//        attackCoolTimeCacl = attackCoolTime;

//        attackRange = 3f;
//        nvAgent.stoppingDistance = 1f;
//    }
//    //    StartCoroutine(ResetAtkArea());


//    //IEnumerator ResetAtkArea()
//    //{
//    //    while (true)
//    //    {
//    //        yield return null;
//    //        if (!meleeAtkArea.activeInHierarchy && currentState == State.Attack)
//    //        {
//    //            yield return new WaitForSeconds(attackCoolTime);
//    //            meleeAtkArea.SetActive(true);
//    //        }
//    //    }
//    //}

//    protected override void InitMonster()
//    {
//        //    maxHp += (StageMgr.Instance.currentStage + 1) * 100f;
//        //    currentHp = maxHp;
//        //    damage += (StageMgr.Instance.currentStage + 1) * 10f;
//    }

//    protected override void AtkEffect()
//    {
//        // Instantiate(EffectSet.Instance.DuckAtkEffect, transform.position, Quaternion.Euler(90, 0, 0));
//    }

//    void Update()
//    {
//        if (currentHp <= 0)
//        {

//        }
//        //if ( enemyCanvasGo.GetComponent<EnemyHpBar> ( ).currentHp <= 0 )
//        //{
//            //nvAgent.isStopped = true;

//            //monsterRigid.gameObject.SetActive(false);
//            //Destroy(transform.parent.gameObject);
//            //return;
//        //}
//    }

//    private void OnCollisionEnter(Collision collision)
//    {
//        if (collision.transform.CompareTag("Player"))
//        {
//            //enemyCanvasGo.GetComponent<EnemyHpBar>().Dmg();
//            currentHp -= 250f;
//            //Instantiate(EffectSet.Instance.DuckDmgEffect, collision.contacts[0].point, Quaternion.Euler(90, 0, 0));
//        }
//    }
//}