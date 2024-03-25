using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float rotationSpeed = 10f;
    public CharacterController controller;
    public Transform groundChek;
    public LayerMask groundMask;
    public float speed = 3f;
    public float gravity = -9.8f;
    public float jumpHeight = 3f;
    Vector3 velocity;
    bool isGrounded;
    private int doubleJump = 1;
    private Animator animator;
    private float animationInterpolation = 1f;
    

    // Start
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        
        isGrounded = Physics.CheckSphere(groundChek.position, 0.3f, groundMask);
        if (isGrounded && velocity.y < 0){
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * y;
        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if(isGrounded){
                doubleJump = 1;
                animator.SetBool("isinAir", false);
        }
        else{
                animator.SetBool("isinAir", true);
        }
        if(Input.GetButtonDown("Jump")){
            if(doubleJump != 0){
                animator.SetTrigger("Jump");
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

            speed =8f;
        }
        else{
            speed = 3f;
        }
    
        animationInterpolation = Mathf.Lerp(animationInterpolation, 1.5f, Time.deltaTime * 3);
        animator.SetFloat("x", Input.GetAxis("Horizontal") * speed);
        animator.SetFloat("y", Input.GetAxis("Vertical") * speed);

    }
    
}
  