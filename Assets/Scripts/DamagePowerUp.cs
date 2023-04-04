using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePowerUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
         if (collision.transform.tag == "Player")
         {
             // do damage here, for example:
            collision.gameObject.GetComponent<Shooting>().damageBUFF = 2f;
            Destroy(gameObject);
            StartCoroutine(DPU());
            collision.gameObject.GetComponent<Shooting>().damageBUFF = 1f;
         }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator DPU(){
        yield return new WaitForSeconds(20);
    }

}
