using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float force = 20f;
    public float damageBuff;

    void Start()
    {
        damageBuff = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            Shoot();
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
