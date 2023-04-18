using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    PlayerStats ps;
    // [SerializeField] private float speed = 100f;
    float yRotation = 1;
    public AudioSource cs;
    // Start is called before the first frame update
    void Start()
    {
        cs = GameObject.FindGameObjectWithTag("cs").GetComponent<AudioSource>();
        ps = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        yRotation += Time.deltaTime * 100f;
        // yRotation *= 1.1f;
        if(yRotation >= 180) yRotation = 1;

        this.transform.eulerAngles = new Vector3(
        this.transform.eulerAngles.x,
        yRotation,
        this.transform.eulerAngles.z
);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
         {
             // do damage here, for example:
                     cs.Play();

             ps.coinPlus(1);
                     Destroy(gameObject);

            // StartCoroutine(yep());
         }
    }
    // IEnumerator yep(){
    //     cs.Play();
    //     yield return new WaitForSeconds(0.1f);
    //     Destroy(gameObject);
    // }
}
