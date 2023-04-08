using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy3 : MonoBehaviour
{
    public float HP;
    float attackRadius = 5f;
    public GameObject GrenadePref;
    public float attackCooldown = 0f;
    public float force = 2.5f;
    Transform target;
    Transform artifact;
    Transform ct;
    NavMeshAgent agent;
    private Transform FP;
    
    void Start()
    {
        FP = gameObject.transform.GetChild(0).gameObject.transform;
        HP = 100f;
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        artifact = GameObject.FindGameObjectWithTag("Artifact").transform;

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
    }
    void Attack(){
        transform.LookAt(ct);
        GameObject grenadeObject = Instantiate(GrenadePref, FP.position, FP.rotation);
        Rigidbody rb = grenadeObject.GetComponent<Rigidbody>();
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



