using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public float HP;
    // Start is called before the first frame update
    void Start()
    {
        HP = 1000f;
    }

    public void TakeDamage(float damage){
        HP -= damage;
        Debug.Log("you take " + damage + " damage");
        if(HP <= 0){
            // Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
