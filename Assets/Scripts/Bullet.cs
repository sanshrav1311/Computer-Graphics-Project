using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float damageBUFF = 1f;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemy")
         {
             collision.gameObject.GetComponent<Enemy>().TakeDamage(50f * damageBUFF);
         }
         if (collision.transform.tag == "bosschotu")
         {
             collision.gameObject.GetComponent<bosschotu>().TakeDamage(50f * damageBUFF);
         }
         if (collision.transform.tag == "boss")
         {
             collision.gameObject.GetComponent<boss>().TakeDamage(50f * damageBUFF);
         }
         if (collision.transform.tag == "Enemy2")
         {
             collision.gameObject.GetComponent<Enemy2>().TakeDamage(50f * damageBUFF);
         }
         if (collision.transform.tag == "Enemy3")
         {
             collision.gameObject.GetComponent<Enemy3>().TakeDamage(50f * damageBUFF);
         }
         if (collision.transform.tag == "Player")
         {
             collision.gameObject.GetComponent<PlayerStats>().TakeDamage(50f);
         }
         if (collision.transform.tag == "Artifact")
         {
             collision.gameObject.GetComponent<ArtifactStats>().TakeDamage(50);
         }
        Destroy(gameObject);
    }
}
