using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Transform playerBody;
    public float mouseSensivity = 100f;
    float xRoration = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensivity * Time.deltaTime;
        xRoration -= mouseY;
        xRoration = Math.Clamp(xRoration, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRoration, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
