using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    public Sprite img;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float force = 1f;
    public float damageBuff;
    public float damage;
    public float timeUntilNextShot;
    public float fireRate;
    public int ammo;
    public AudioSource cs;
    // cs = GameObject.FindGameObjectWithTag("ss").GetComponent<AudioSource>();
    void Start()
    {
        firePoint = GameObject.FindGameObjectWithTag("FP").transform;
        cs = GameObject.FindGameObjectWithTag("ss").GetComponent<AudioSource>();
        damageBuff = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && timeUntilNextShot < Time.time && ammo > 0) // Fire Input
        {
            Shoot();
            timeUntilNextShot = Time.time + fireRate; // Fire Rate
        }
    }

    public void changeDamageBuff(int db){
        StartCoroutine(DPU(db));
    }
    IEnumerator DPU(int db){
        damageBuff = db;
        yield return new WaitForSeconds(20);
        damageBuff = 1f;
    }
    void Shoot(){
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        bullet.GetComponent<Bullet>().damageBUFF = damageBuff * damage;
        rb.AddForce(firePoint.forward * force, ForceMode.Impulse);
        ammo -= 1;
        cs.Play();
    }
    public void assignAmmo(int a){
        ammo = a;
    }
}
