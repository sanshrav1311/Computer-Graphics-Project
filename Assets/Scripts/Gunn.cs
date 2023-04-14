using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gun;
    public TimeController a;
        void Start()
        {
        a = GameObject.FindGameObjectWithTag("time").GetComponent<TimeController>();
            
        }
        void Update()
        {
if(a.currentTime.Hour == 12){
            Destroy(gameObject);
        }
            
        }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
         {
             collision.gameObject.GetComponent<PlayerStats>().changeGun(gun);
            Destroy(gameObject);
         }

    }
}
