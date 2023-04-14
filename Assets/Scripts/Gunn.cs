using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gun;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
         {
             collision.gameObject.GetComponent<PlayerStats>().changeGun(gun);
            Destroy(gameObject);
         }

    }
}
