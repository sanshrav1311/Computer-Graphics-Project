using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactStats : MonoBehaviour
{
    public float artifactHP;
    // Start is called before the first frame update
    void Start()
    {
        artifactHP = 100000f;
    }
    public void TakeDamage(int damage){
        artifactHP -= damage;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
