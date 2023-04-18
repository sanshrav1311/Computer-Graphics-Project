using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ArtifactStats : MonoBehaviour
{
    public float artifactHP;
    public float aMaxHP = 10000f;
    public GameObject target;
    private int coins;
    public Slider HealthBar;
     public AudioSource cs;

    // Start is called before the first frame update
    void Start()
    {
    cs = GameObject.FindGameObjectWithTag("bs").GetComponent<AudioSource>();
        target = GameObject.FindGameObjectWithTag("Player");
        artifactHP = 10000f;
        HealthBar.value = artifactHP;
    }
    public void healCrystal(){
        coins = target.GetComponent<PlayerStats>().coins;
        if(coins >= 2 && artifactHP != aMaxHP){
            if(artifactHP + 1000 <= aMaxHP)
            {artifactHP += 1000f;}
            else
            {
                artifactHP = aMaxHP;
            }
            target.GetComponent<PlayerStats>().coinPlus(-2);
            cs.Play();
        }
    }
    public void TakeDamage(int damage){
        artifactHP -= damage;
        HealthBar.value = artifactHP;
        // Debug.Log(damage);
        if(artifactHP <= 0){
                    Cursor.lockState = CursorLockMode.None;

            SceneManager.LoadScene(2);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
