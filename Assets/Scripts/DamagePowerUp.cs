using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePowerUp : MonoBehaviour
{
    Shooting ps;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
         if (collision.transform.tag == "Player")
         {
             // do damage here, for example:
            ps = collision.gameObject.GetComponent<PlayerStats>().Gun1.GetComponent<Shooting>();
            ps.changeDamageBuff(2);
            Destroy(gameObject);
         }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


    // void OnCollisionEnter(Collision collision)
    // {
    //      if (collision.transform.tag == "Player")
    //      {
    //          // do damage here, for example:
    //         collision.gameObject.GetComponent<Shooting>().changeDamageBuff(2);
    //         Destroy(gameObject);
            
    //      }
        
    // }