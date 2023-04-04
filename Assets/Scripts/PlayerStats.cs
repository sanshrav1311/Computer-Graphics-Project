using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public float HP;
    public int coins;
    public int score;
    public float invincible;
    // Start is called before the first frame update
    void Start()
    {
        HP = 1000f;
        coins = 0;
        score = 0;
        invincible = 1f;

    }

    public void TakeDamage(float damage){
        HP -= damage * invincible;
        Debug.Log("you take " + damage + " damage");
        if(HP <= 0){
            // Destroy(gameObject);
        }
    }
    public void changeInvincibility(int iv){
        StartCoroutine(DPU(iv));
    }
    IEnumerator DPU(int iv){
        invincible = iv;
        yield return new WaitForSeconds(20);
        invincible = 1f;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
