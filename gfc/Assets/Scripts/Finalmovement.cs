using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Finalmovement : MonoBehaviour
{
    private float m_JumpForce = 400f;							// Amount of force added when the player jumps.
	//[SerializeField] private bool m_AirControl = false;							// Whether or not a player can steer while jumping;
	[SerializeField] private LayerMask m_WhatIsGround;							// A mask determining what is ground to the character
	[SerializeField] private Transform m_GroundCheck;							// A position marking where to check if the player is grounded.
	const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
	public bool m_Grounded;            // Whether or not the player is grounded.
	private Rigidbody2D rb;
	private bool m_FacingRight = true;  // For determining which way the player is currently facing.
	private Vector3 m_Velocity = Vector3.zero;
	public Animator animator;

    public float runSpeed=40f;
    float  horizontalMove;

    //bool jump= false;

    public float dashtime=0.5f;

    public float cooldown;
    private float timepassed;

    public float mnoznikspeed;
    private float startspeed;

    // Start is called before the first frame update
    [Header("Events")]
	[Space]

	public UnityEvent OnLandEvent;
	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();

		if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();
	}

    private void FixedUpdate()
	{
       // Move(horizontalMove * Time.fixedDeltaTime, jump);
	   rb.velocity = new Vector2(horizontalMove * runSpeed, rb.velocity.y);
       // jump= false;

		bool wasGrounded = m_Grounded;
		m_Grounded = false;
		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);	// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		for (int i = 0; i < colliders.Length; i++) // This can be done using layers instead but Sample Assets will not overwrite your project settings.
		{
			if (colliders[i].gameObject != gameObject)
			{
				m_Grounded = true;
				if (!wasGrounded)
					OnLandEvent.Invoke();
			}
		}
		if (m_Grounded){
			animator.SetBool("onfloor", true);
		}
		else {
			animator.SetBool("onfloor", false);
		}
	}
    private void Flip()
	{
		if(m_FacingRight &&  horizontalMove <0f ||!m_FacingRight && horizontalMove > 0f) {
			m_FacingRight = !m_FacingRight; 		// Switch the way the player is labelled as facing.
			Vector3 theScale = transform.localScale;  	// Multiply the player's x local scale by -1.
			theScale.x *= -1;
			transform.localScale = theScale;			
		}
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

	//public void Move(float move, bool jump)
	//{
	//	if (m_Grounded || m_AirControl) 		//only control the player if grounded or airControl is turned on
	//	{
			//Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y); 		// Move the character by finding the target velocity
			//m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing); 	// And then smoothing it out and applying it to the character

			//if (move > 0 && !m_FacingRight) 			// If the input is moving the player right and the player is facing left...
		//	{
		//		Flip();
		//	}
		//	else if (move < 0 && m_FacingRight) 		// Otherwise if the input is moving the player left and the player is facing right...
		//	{
		//		Flip();
		//	}
		//}
	//	if (m_Grounded && jump) 		// If the player should jump...
	//	{
	//		m_Grounded = true; 			// Add a vertical force to the player.
	//		m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce)); 
	//	}
	//	if (m_Grounded){
		//	animator.SetBool("onfloor", true);
	//	}
//else {
	//		animator.SetBool("onfloor", false);
//}
//	}


    void Start()
    {
        startspeed = runSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        horizontalMove = Input.GetAxisRaw("Horizontal");
        if(Input.GetButtonDown("Jump") && m_Grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, m_JumpForce);
            animator.SetBool("IsJumping",true);
        } 
		if (Input.GetButtonUp("Jump") && rb.velocity.y >0f) { 
			rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
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
		Flip();
        
    }
}
	//public void Move(float move, bool jump)
	//{
	//	if (m_Grounded || m_AirControl) 		//only control the player if grounded or airControl is turned on
	//	{
			//Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y); 		// Move the character by finding the target velocity
			//m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing); 	// And then smoothing it out and applying it to the character

			//if (move > 0 && !m_FacingRight) 			// If the input is moving the player right and the player is facing left...
		//	{
		//		Flip();
		//	}
		//	else if (move < 0 && m_FacingRight) 		// Otherwise if the input is moving the player left and the player is facing right...
		//	{
		//		Flip();
		//	}
		//}
	//	if (m_Grounded && jump) 		// If the player should jump...
	//	{
	//		m_Grounded = true; 			// Add a vertical force to the player.
	//		m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce)); 
	//	}
	//	if (m_Grounded){
		//	animator.SetBool("onfloor", true);
	//	}
//else {
	//		animator.SetBool("onfloor", false);
//}
//	}