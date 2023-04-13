using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUpSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject powerUp;
    [SerializeField]
    private GameObject powerUp2;
    [SerializeField]
    private GameObject powerUp3;
    [SerializeField]
    private GameObject Gun;
    [SerializeField]
    private GameObject Gun2;
    [SerializeField]
    private GameObject Gun3;

    [SerializeField]
    private float interval = 20f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(interval, powerUp));
        StartCoroutine(spawnEnemy(interval, powerUp2));
        StartCoroutine(spawnEnemy(interval, powerUp3));
        StartCoroutine(spawnEnemy(interval, Gun));
        StartCoroutine(spawnEnemy(interval, Gun2));
        StartCoroutine(spawnEnemy(interval, Gun3));
    }

    // Update is called once per frame
    private IEnumerator spawnEnemy(float interval, GameObject enemy){
        yield return new WaitForSeconds(interval + Random.Range(-1.5f, 1.5f));
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-11f, 8f),0.92f,Random.Range(-17f, 6f)),Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
