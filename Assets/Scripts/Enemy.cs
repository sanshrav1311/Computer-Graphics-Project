using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float HP;
    public float attackRadius = 10f;
    
    void Start()
    {
        HP = 100f;
    }

    void Update()
    {
        if(HP <= 0)
        {
            Destroy(gameObject);
        } 
    }

    public void TakeDamage(float damage)
    {
        HP -= damage;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }

}



