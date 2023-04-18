using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class boss : MonoBehaviour
{
    // Start is called before the first frame update
    public float HP;
    float attackRadius = 10f;
    public GameObject GrenadePref;
    public float attackCooldown = 0f;
    public float force = 2.5f;
    Transform target;
    UnityEngine.AI.NavMeshAgent agent;
    private Transform FP;
    public TimeController a;
    public float bmaxHP = 2000f;
    // public Slider HealthBar;
    public GameObject q;
    public bossspawn bss;
    void Start()
    {
        // HealthBar = Slider.FindSliderWithTag("bar");
        // HealthBar = GameObject.FindGameObjectWithTag("barobj").GetComponent<Slider>();
        q = GameObject.FindGameObjectWithTag("barobj");
         bss = GameObject.FindGameObjectWithTag("bossspawn").GetComponent<bossspawn>();
        FP = gameObject.transform.GetChild(0).gameObject.transform;
        FP = gameObject.transform.GetChild(0).gameObject.transform;
        a = GameObject.FindGameObjectWithTag("time").GetComponent<TimeController>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        HP = 2000f;
        // HealthBar.maxValue = HP;
        // q.SetActive(true);
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
                q = GameObject.FindGameObjectWithTag("barobj");

        attackCooldown -= Time.deltaTime;
        float distance = Vector3.Distance(target.position, transform.position);
       
        if(distance >= attackRadius)
        {
            agent.SetDestination(target.position);   
        }
        else{
            if(attackCooldown <= 0){
                Attack();
            }
        }
        if(a.currentTime.Hour == 12){
            bss.spawned = false;
            q.SetActive(false);
            Destroy(gameObject);
        }
        // HealthBar.value = HP;
    }
    void Attack(){
        transform.LookAt(target);
        GameObject grenadeObject = Instantiate(GrenadePref, FP.position, FP.rotation);
        Rigidbody rb = grenadeObject.GetComponent<Rigidbody>();
        rb.AddForce(FP.forward * force, ForceMode.Impulse);
        setAttackCooldown();
    }
    public void TakeDamage(float damage)
    {
        HP -= damage;
        if(HP <= 0)
        {
            q.SetActive(false);
            bss.spawned = false;
            a.currentTime = new System.DateTime(a.currentTime.Year, a.currentTime.Month, a.currentTime.Day, 12, a.currentTime.Minute, a.currentTime.Second);
            Destroy(gameObject);
        }
        // HealthBar.value = HP;
    }

    void setAttackCooldown(){
        attackCooldown = 2f;
    }
}
