using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class boss : MonoBehaviour
{
    // Start is called before the first frame update
    public float HP;
    float attackRadius = 10f;
    public GameObject GrenadePref;
    public float attackCooldown = 0f;
    public float force = 2.5f;
    Transform target;
    UnityEngine.AI.NavMeshAgent agent;
    private Transform FP;
    
    void Start()
    {
        FP = gameObject.transform.GetChild(0).gameObject.transform;
        HP = 2000f;
        // agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
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
    }
    void Attack(){
        transform.LookAt(target);
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
        attackCooldown = 2f;
    }
}
