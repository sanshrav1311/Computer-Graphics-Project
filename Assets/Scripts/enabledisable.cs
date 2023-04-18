using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enabledisable : MonoBehaviour
{
    public TimeController a;
    public GameObject e;
    public GameObject b;
    public bool once = true;
    public int d;
    // Start is called before the first frame update
    void Start()
    {
        a = GameObject.FindGameObjectWithTag("time").GetComponent<TimeController>();
    }

    // Update is called once per frame
    void Update()
    {
        d = a.DayCount;
        if(d % 3 != 0){
            if(once){
                e.SetActive(true);
                b.SetActive(false);
                once = false;
            }
        }
        else{
            if(!once){
                e.SetActive(false);
                b.SetActive(true);
                once = true;
            }
        }
    }
}
