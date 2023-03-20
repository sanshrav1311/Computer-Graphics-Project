using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // public float playerSpeed;
    // public float walkSpeed = 2f;
    // public float mouseSensitivity = 2f;
    // public float jumpHeight = 3f;
    // private bool isMoving = false;
    // private float yRot;
 
    // private Animator anim;
    // private Rigidbody rigidBody;
    private Rigidbody rb;
    private float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horizontalInput * speed, 0, verticalInput * speed);
        // if(Input.GetKeyDown("space") && transform.position.y <= 1){
        //     GetComponent<Rigidbody>().velocity = new Vector3(0, 5, 0);
        // }
        // if (Input.GetKey(KeyCode.RightArrow)){
		// 	transform.position += Vector3.right * speed * Time.deltaTime;
		// }
		// if (Input.GetKey(KeyCode.LeftArrow)){
		// 	transform.position += Vector3.left * speed * Time.deltaTime;
		// }
		// if (Input.GetKey(KeyCode.UpArrow)){
		// 	transform.position += Vector3.forward * speed * Time.deltaTime;
		// }
		// if (Input.GetKey(KeyCode.DownArrow)){
		// 	transform.position += Vector3.back * speed * Time.deltaTime;
		// }     
        // yRot += Input.GetAxis("Mouse X") * mouseSensitivity;
        // transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, yRot, transform.localEulerAngles.z);
 
        // isMoving = false;
 
        // if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        // {
        //     //transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * playerSpeed);
        //     rigidBody.velocity += transform.right * Input.GetAxisRaw("Horizontal") * playerSpeed;
        //     isMoving = true;
        // }
        // if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        // {
        //     //transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * playerSpeed);
        //     rigidBody.velocity += transform.forward * Input.GetAxisRaw("Vertical") * playerSpeed;
        //     isMoving = true;
        // }
 
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     transform.Translate(Vector3.up * jumpHeight);
        // }
 
        // if (Input.GetAxisRaw("Sprint") > 0f)
        // {
        //     playerSpeed = sprintSpeed;
        //     isSprinting = true;
        // }else if (Input.GetAxisRaw("Sprint") < 1f)
        // {
        //     playerSpeed = walkSpeed;
        //     isSprinting = false;
        // }
 
        // anim.SetBool("isMoving", isMoving);
        // anim.SetBool("isSprinting", isSprinting);
    }
}
