using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    // public GameObject hitEffect;

    // void OnTriggerEnter(Collider other)
    // {
    //     if(other.gameObject.name.Equals("Enemy"))
    //     {
    //         other.GetComponent<Enemy>().HP -= 50;
    //     }
    

    // }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemy")
         {
             // do damage here, for example:
             collision.gameObject.GetComponent<Enemy>().TakeDamage(50f);
         }
        // GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        // Destroy(effect, 5f);
        Destroy(gameObject);
    }

}
