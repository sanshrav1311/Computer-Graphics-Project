using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawing : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private GameObject enemyPrefab2;
    [SerializeField]
    private GameObject enemyPrefab3;

    [SerializeField]
    private float interval = 10f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(interval, enemyPrefab));
        StartCoroutine(spawnEnemy(interval, enemyPrefab2));
        StartCoroutine(spawnEnemy(interval, enemyPrefab3));
    }

    // Update is called once per frame
    private IEnumerator spawnEnemy(float interval, GameObject enemy){
        yield return new WaitForSeconds(interval + Random.Range(-1.5f, 1.5f));
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-11f, 8f),0.92f,Random.Range(-17f, 6f)),Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
