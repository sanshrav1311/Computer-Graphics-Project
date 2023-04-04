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
            collision.gameObject.GetComponent<Shooting>().changeDamageBuff(2);
            Destroy(gameObject);
            
         }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }


}
