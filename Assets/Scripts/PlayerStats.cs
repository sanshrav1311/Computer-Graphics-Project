using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class PlayerStats : MonoBehaviour
{
    public float HP;
    public float maxHP = 1000f;
    public int coins;
    public int score;
    public float invincible;
    public Transform firePoint;
    public GameObject Gun1;
    public GameObject Gun2;
    public int g2ammo;
    public GameObject inHand;
    public GameObject pistol;
    public GameObject mgun;
    public GameObject sniper;
    public TextMeshProUGUI COINStext;
    public Slider HealthBar;
     public AudioSource cs;
    // Start is called before the first frame update
    void Start()
    {
    cs = GameObject.FindGameObjectWithTag("bs").GetComponent<AudioSource>();
        HP = 1000f;
        HealthBar.value = HP;
        coins = 0;
        score = 0;
        invincible = 1f;
        firePoint = GameObject.FindGameObjectWithTag("FP").transform;
        inHand = Instantiate(Gun1, firePoint.position, firePoint.rotation, this.transform);
        g2ammo = Gun2.GetComponent<Shooting>().ammo;
        COINStext.text=GetComponent<TMPro.TextMeshProUGUI>().text;


    }

    public void TakeDamage(float damage){
        HP -= damage * invincible;
        // Debug.Log("you take " + damage + " damage");
        if(HP <= 0){
            // Destroy(gameObject);
                    Cursor.lockState = CursorLockMode.None;

            SceneManager.LoadScene(2);
        }
        HealthBar.value = HP;
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
        if(Input.GetKeyDown("f")){
            int t = inHand.GetComponent<Shooting>().ammo;
            GameObject temp = Gun1;
            Gun1 = Gun2;
            Gun2 = temp;
            Destroy(inHand);
            inHand = Instantiate(Gun1, firePoint.position, firePoint.rotation, this.transform);
            inHand.GetComponent<Shooting>().assignAmmo(g2ammo);
            g2ammo = t;
        }
        HealthBar.value = HP;

    }

    public void changeGun(GameObject a){
        Destroy(inHand);
        inHand = Instantiate(a, firePoint.position, firePoint.rotation, this.transform);
    }
    // onKeyDown();
    public void coinPlus(int x){
        coins += x;
        COINStext.text=coins.ToString();
    }
    public void updateMaxHp(){
        if(coins >= 3){
            maxHP += 200;
            HP += 200;
            HealthBar.maxValue = maxHP;
            coinPlus(-3);
            cs.Play();
        }
    }
}
