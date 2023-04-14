using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossspawn : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject enemyPrefab;
    public TimeController a;
    void Start()
    {
                a = GameObject.FindGameObjectWithTag("time").GetComponent<TimeController>();

    }
    void Update()
    {
        if(a.DayCount % 3 == 0){
            Instantiate(enemyPrefab, new Vector3(0.0191474f,0.92f,25.55f),Quaternion.identity);
        }
    }
}
