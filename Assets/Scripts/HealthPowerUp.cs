using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{
    PlayerStats ps;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnCollisionEnter(Collision collision)  
    {
         if (collision.transform.tag == "Player")
         {
             // do damage here, for example:
            ps = collision.gameObject.GetComponent<PlayerStats>();
            if(ps.HP + 200 > 1000){
                ps.HP = 1000;
            }
            else{
                ps.HP += 200;
            }

            Destroy(gameObject);

         }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
