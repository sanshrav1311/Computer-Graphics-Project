using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{
    PlayerStats ps;
    public TimeController a;
    // Start is called before the first frame update
    void Start()
    {
        a = GameObject.FindGameObjectWithTag("time").GetComponent<TimeController>();
        
    }
    void OnCollisionEnter(Collision collision)  
    {
         if (collision.transform.tag == "Player")
         {
             // do damage here, for example:
            ps = collision.gameObject.GetComponent<PlayerStats>();
            if(ps.HP + 200 > ps.maxHP){
                ps.HP = ps.maxHP;
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
if(a.currentTime.Hour == 12){
            Destroy(gameObject);
        }
        
    }
}
