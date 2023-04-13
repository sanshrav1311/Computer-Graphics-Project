using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private ParticleSystem Rain;
    public ParticleSystem old;
    private GameObject plane;
    [SerializeField]
    private float interval = 5.3f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(interval, Rain));
    }

    // Update is called once per frame
    private IEnumerator spawnEnemy(float interval, ParticleSystem Rain){
        yield return new WaitForSeconds(interval + Random.Range(-1.5f, 1.5f));
        ParticleSystem newEnemy = Instantiate(Rain, new Vector3(Random.Range(-11f, 8f),25.8f,Random.Range(-17f, 6f)),Quaternion.identity);
        plane = old.transform.GetChild(0).gameObject;
        Destroy(plane);
        Destroy(old);
        old = newEnemy;
        StartCoroutine(spawnEnemy(interval, Rain));
    }
}
