using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvicibilityPowerUp : MonoBehaviour
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
            ps.changeInvincibility(0);
            Destroy(gameObject);
         }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
