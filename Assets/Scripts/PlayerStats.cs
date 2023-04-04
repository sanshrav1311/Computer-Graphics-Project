using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public float HP;
    public int coins;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        HP = 1000f;
        coins = 0;
        score = 0;
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
