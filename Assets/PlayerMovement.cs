using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform groundChek;
    public LayerMask groundMask;
    public float speed = 10f;
    public float gravity = -9.8f;
    public float jumpHeight = 3f;
    Vector3 velocity;
    bool isGrounded;
    public float groundDistance = 0.4f;
    private int doubleJump = 2;
    private Animator animator;

    // Start
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        
        isGrounded = Physics.CheckSphere(groundChek.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0){
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if(isGrounded){
                doubleJump = 2;
        }

        if(Input.GetButtonDown("Jump")){
            if(doubleJump != 0){
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                doubleJump -= 1;
            }
        }
        if (Input.GetKey("c")){
            controller.height = 1f;
        }
        else{
            controller.height = 2f;
        }
        if (Input.GetKey("left shift")){

            speed =20f;
        }
        else{
            speed = 10f;
        }
        animator.SetFloat("speed", Vector3.ClampMagnitude(new Vector3(x, 0, z), 1).magnitude * speed);
        
    }
}
