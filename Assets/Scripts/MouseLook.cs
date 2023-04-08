using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{   
    public Vector2 turn;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        turn.x += Input.GetAxis("Mouse X");
        transform.localRotation = Quaternion.Euler(0, turn.x, 0);
    }

    void FixedUpdate()
    {

    }
}