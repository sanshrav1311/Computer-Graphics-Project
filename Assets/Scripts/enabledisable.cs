using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enabledisable : MonoBehaviour
{
    public TimeController a;
    public GameObject e;
    public GameObject b;
    public bool once = true;

    // Start is called before the first frame update
    void Start()
    {
        a = GameObject.FindGameObjectWithTag("time").GetComponent<TimeController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(a.DayCount % 3 == 0){
            if(once){
                b.SetActive(true);
                e.SetActive(false);
                once = false;
            }
        }
        else{
            if(!once){
                b.SetActive(false);
                e.SetActive(true);
                once = true;
            }
        }
    }
}
