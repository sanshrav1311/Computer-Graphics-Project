using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    // public GameObject hitEffect;
    // void OnTriggerEnter(Collider other)
    // {
    //     if(other.gameObject.name.Equals("Enemy"))
    //     {
    //         other.GetComponent<Enemy>().HP -= 50;
    //     }
    // }
    GameObject target;
    GameObject artifact;
    public ParticleSystem smoke;
    private float smokeTime = 2f;
    public AudioSource cs;
    void smokeFun()
{
    ParticleSystem smokeInstance = Instantiate(smoke, transform.position, transform.rotation) as ParticleSystem;
    Destroy(smokeInstance.gameObject, smokeTime);
}

    void Start() {
    cs = GameObject.FindGameObjectWithTag("sss").GetComponent<AudioSource>();
        target = GameObject.FindGameObjectWithTag("Player");
        artifact = GameObject.FindGameObjectWithTag("Artifact");
        StartCoroutine(explode());       
    }
    IEnumerator explode(){
        yield return new WaitForSeconds(0.7f);
        float distance = Vector3.Distance(target.transform.position, transform.position);
        if(distance <= 1f){
            target.GetComponent<PlayerStats>().TakeDamage(100f);
        }
        distance = Vector3.Distance(artifact.transform.position, transform.position);
        if(distance <= 1f){
            artifact.GetComponent<ArtifactStats>().TakeDamage(100);
        }
        smokeFun();
        cs.Play();
        Destroy(gameObject);
    }
    public float damageBUFF = 1f;
    void OnCollisionEnter(Collision collision)
    {
         if (collision.transform.tag == "Player")
         {
             // do damage here, for example:
             collision.gameObject.GetComponent<PlayerStats>().TakeDamage(100f);
         }
         if (collision.transform.tag == "Artifact")
         {
             // do damage here, for example:
             collision.gameObject.GetComponent<ArtifactStats>().TakeDamage(100);
         }
        smokeFun();
        cs.Play();
        Destroy(gameObject);
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
        // GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        // Destroy(effect, 5f);
    }
}
