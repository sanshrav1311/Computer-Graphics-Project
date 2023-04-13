using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
    public float attackCooldown = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         attackCooldown -= Time.deltaTime;
    }
    void OnCollisionEnter(Collision collision)
    {
         if (collision.transform.tag == "Player")
         {
            if(attackCooldown <= 0){
                damage(collision);
            }
         }
    }
    void setAttackCooldown(){
        attackCooldown = 1f;
    }
    void damage(Collision collision){
        collision.gameObject.GetComponent<PlayerStats>().TakeDamage(10f);
        setAttackCooldown();
    }
}
