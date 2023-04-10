using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float force = 1f;
    public float damageBuff;
    public float timeUntilNextShot;
    public float fireRate;

    void Start()
    {
        firePoint = GameObject.FindGameObjectWithTag("FP").transform;
        damageBuff = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && timeUntilNextShot < Time.time) // Fire Input
        {
            Shoot();
            timeUntilNextShot = Time.time + fireRate; // Fire Rate
        }
    }

    void Shoot(){
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        bullet.GetComponent<Bullet>().damageBUFF = damageBuff;
        rb.AddForce(firePoint.forward * force, ForceMode.Impulse);
    }
    public void changeDamageBuff(int db){
        StartCoroutine(DPU(db));
    }
    IEnumerator DPU(int db){
        damageBuff = db;
        yield return new WaitForSeconds(20);
        damageBuff = 1f;
    }
}
