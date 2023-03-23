using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float HP;
    float attackRadius = 5f;
    
    Transform target;
    NavMeshAgent agent;
    
    void Start()
    {
        HP = 100f;
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if(distance >= attackRadius)
        {
            agent.SetDestination(target.position);   
        }
    }

    public void TakeDamage(float damage)
    {
        HP -= damage;
        if(HP <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 5f);
    }

}



