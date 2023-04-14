using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy2 : MonoBehaviour
{
    public float HP;
    float attackRadius = 0.75f;
    public float attackCooldown = 0f;
    public float force = 5f;
    Transform target;
    PlayerStats ps;

    NavMeshAgent agent;
    private Transform FP;
        public TimeController a;

    void Start()
    {
        FP = gameObject.transform.GetChild(0).gameObject.transform;
        HP = 50f;
        agent = GetComponent<NavMeshAgent>();
        ps = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
                a = GameObject.FindGameObjectWithTag("time").GetComponent<TimeController>();

    }

    void Update()
    {
        attackCooldown -= Time.deltaTime;
        float distance = Vector3.Distance(target.position, transform.position);
       
        if(distance >= attackRadius)
        {
            agent.SetDestination(target.position);   
        }
        else{
            if(attackCooldown <= 0){
                Attack();
            }
        }
        if(a.currentTime.Hour == 12){
            Destroy(gameObject);
        }
    }
    void Attack(){
        ps.TakeDamage(25);
        setAttackCooldown();
    }
    public void TakeDamage(float damage)
    {
        HP -= damage;
        if(HP <= 0)
        {
            Destroy(gameObject);
        }
    }

    void setAttackCooldown(){
        attackCooldown = 1f;
    }
}



