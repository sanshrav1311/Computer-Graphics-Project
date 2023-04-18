using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class bossspawn : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private GameObject enemyPrefab2;
    public TimeController a;
    public bool spawned = false;
    public float spawnRate = 0f;
    public Slider HealthBar;
    public GameObject q; 
    public GameObject BOSS;
    public void setSpawnRate(){
        spawnRate = 5f;
    }


    void Start()
    {
        a = GameObject.FindGameObjectWithTag("time").GetComponent<TimeController>();
        spawned = false;

    }
    void Update()
    {
        spawnRate -= Time.deltaTime;
        HealthBar.value = BOSS.GetComponent<boss>().HP;
    }
    void LateUpdate()
    {
        if(spawnRate <= 0){
            GameObject newEnemy = Instantiate(enemyPrefab2, new Vector3(Random.Range(-11f, 8f),0.92f,Random.Range(-17f, 6f)),Quaternion.identity);
            setSpawnRate();
        }
            if(spawned == false){
                BOSS = Instantiate(enemyPrefab, new Vector3(-4.663539f,0.67f,4.79f),Quaternion.identity);
                HealthBar.maxValue = 2000f;
                q.SetActive(true);
                spawned = true;
            }
        
    }
}
