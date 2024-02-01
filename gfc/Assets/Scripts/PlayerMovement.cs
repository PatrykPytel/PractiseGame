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

    public float dashtime=0.5f;

    public float cooldown;
    private float timepassed;

    public float mnoznikspeed;
    private float startspeed;

    public bool isWallSliding;
    private float WallSlidingSpeed = 10f;

    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private Transform wallCheck;
 

    // Update is called once per frame
    void Start() { 
        startspeed = runSpeed;
    }
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
                runSpeed = runSpeed * mnoznikspeed;
            Invoke("stopdash", dashtime);   
            } 
        }
        else { 
            timepassed -= Time.deltaTime;
        }
        WallSlide();
    
    }
    void stopdash()
    {
        runSpeed = runSpeed/mnoznikspeed;
        animator.SetBool("Isdashing", false);
        animator.SetBool("IsJumping",true);

    }
    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump= false;

    }
    public void Attackmovement() {
        runSpeed = 0f;
        Debug.Log("nieruszam sei");
    }
    public void Notattacking() {
        runSpeed = startspeed ;
    }

    private bool IsWalled() { 
        return Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer);
    }
    private void WallSlide() { 
        if (IsWalled() && !controller.m_Grounded && horizontalMove != 0f) { 
            isWallSliding = true;
            controller.m_Rigidbody2D.velocity = new Vector2(controller.m_Rigidbody2D.velocity.x, Mathf.Clamp(controller.m_Rigidbody2D.velocity.y, -WallSlidingSpeed, float.MaxValue ));
        } else { 
            isWallSliding = false;
        }
    }
}
