using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float HP;
    float attackRadius = 5f;
    public GameObject bulletPrefab;
    public float attackCooldown = 0f;
    public float force = 5f;
    Transform target;
    Transform artifact;
    Transform ct;
    NavMeshAgent agent;
    private Transform FP;
    public TimeController a;
    
    void Start()
    {
        FP = gameObject.transform.GetChild(0).gameObject.transform;
        HP = 100f;
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        artifact = GameObject.FindGameObjectWithTag("Artifact").transform;
        a = GameObject.FindGameObjectWithTag("time").GetComponent<TimeController>();

    }

    void Update()
    {
        attackCooldown -= Time.deltaTime;
        float distance = Vector3.Distance(target.position, transform.position);
        ct = target;
        if(distance > Vector3.Distance(artifact.position, transform.position)){
            distance = Vector3.Distance(artifact.position, transform.position);
            ct = artifact;
        }
        if(distance >= attackRadius)
        {
            agent.SetDestination(ct.position);   
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
        transform.LookAt(ct);
        GameObject bullet = Instantiate(bulletPrefab, FP.position, FP.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(FP.forward * force, ForceMode.Impulse);
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



