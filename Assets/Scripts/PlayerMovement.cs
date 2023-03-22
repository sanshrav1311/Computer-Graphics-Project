using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private float speed = 2f;
    private Transform t;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        t = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion q = new Quaternion(0,0,0,1);
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float angle = t.rotation.eulerAngles.y;
        float sinY = Mathf.Sin((angle * Mathf.PI)/180);
        float cosY = Mathf.Cos((angle * Mathf.PI)/180);
        // Debug.Log(cosY + " " + sinY + " " + angle + " " + horizontalInput);
        float movX = (verticalInput * speed * sinY) + (horizontalInput * speed * cosY);
        float movZ = (verticalInput * speed * cosY) + (-1 * horizontalInput * speed * sinY); 
        rb.velocity = new Vector3(movX, 0, movZ);
    }
}
