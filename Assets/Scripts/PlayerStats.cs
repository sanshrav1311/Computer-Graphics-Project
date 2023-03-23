using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public float HP;
    // Start is called before the first frame update
    void Start()
    {
        HP = 100f;
    }

    public void TakeDamage(float damage){
        //HP -= 50f;
        Debug.Log("you take " + damage + " damage");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
