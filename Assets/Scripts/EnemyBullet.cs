using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    // public GameObject hitEffect;
    // void OnTriggerEnter(Collider other)
    // {
    //     if(other.gameObject.name.Equals("Enemy"))
    //     {
    //         other.GetComponent<Enemy>().HP -= 50;
    //     }
    // }
    public float damageBUFF = 1f;
    void OnCollisionEnter(Collision collision)
    {
        // if (collision.transform.tag == "Enemy")
        //  {
        //      // do damage here, for example:
        //      collision.gameObject.GetComponent<Enemy>().TakeDamage(50f * damageBUFF);
        //  }
        //  if (collision.transform.tag == "Enemy2")
        //  {
        //      // do damage here, for example:
        //      collision.gameObject.GetComponent<Enemy2>().TakeDamage(50f * damageBUFF);
        //  }
         if (collision.transform.tag == "Player")
         {
             // do damage here, for example:
             collision.gameObject.GetComponent<PlayerStats>().TakeDamage(50f * damageBUFF);
         }
         if (collision.transform.tag == "Artifact")
         {
             // do damage here, for example:
             collision.gameObject.GetComponent<ArtifactStats>().TakeDamage(50);
         }
        // GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        // Destroy(effect, 5f);
        Destroy(gameObject);
    }
}
