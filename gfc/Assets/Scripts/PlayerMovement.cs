using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public float runSpeed=40f;
    float  horizontalMove =0f;
    bool jump= false;
    bool crouch =false;

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        horizontalMove = Input.GetAxisRaw("Horizontal")* runSpeed;
        if(Input.GetButtonDown("Jump"))
        {
            jump =true;
            animator.SetBool("IsJumping",true);
        } 
        if(Input.GetButtonDown("Crouch"))
        {
            crouch=true;

        } else if(Input.GetButtonUp("Crouch"))
        {
            crouch= false;
        } else if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            runSpeed = 1500000000f;
            while (runSpeed>40f) 
            {
                runSpeed= runSpeed - 0.001f;
            }
            runSpeed = 40f;
        } 
    }
    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime,crouch, jump);
        jump= false;

    }
}
