using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
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
         }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
