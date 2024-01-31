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
    public float dashtime=0.5f;
    public float cooldown;
    private float timepassed;

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
        if (timepassed <= 0) {  
            if(Input.GetKeyDown(KeyCode.LeftShift))
            {
                timepassed =cooldown;
                animator.SetBool("Isdashing", true);
                animator.SetBool("IsJumping", false);
                runSpeed = 250f;
            Invoke("stopdash", dashtime);   
            } 
        }
        else { 
            timepassed -= Time.deltaTime;
        }
    }
    void stopdash()
    {
        runSpeed = 40f;
        animator.SetBool("Isdashing", false);
        animator.SetBool("IsJumping",true);

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
