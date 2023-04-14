using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossspawn : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject enemyPrefab;
    public TimeController a;
    public bool spawned = false;
    void Start()
    {
                a = GameObject.FindGameObjectWithTag("time").GetComponent<TimeController>();
                spawned = false;

    }
    void Update()
    {
            if(spawned == false){
                Instantiate(enemyPrefab, new Vector3(-4.663539f,0.678f,4.79f),Quaternion.identity);
                spawned = true;
            }
        
    }
}
