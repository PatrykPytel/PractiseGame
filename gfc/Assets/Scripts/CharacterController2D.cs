using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
	[SerializeField] private float m_JumpForce = 400f;							// Amount of force added when the player jumps.
				// Amount of maxSpeed applied to crouching movement. 1 = 100%
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;	// How much to smooth out the movement
	[SerializeField] private bool m_AirControl = false;							// Whether or not a player can steer while jumping;
	[SerializeField] private LayerMask m_WhatIsGround;							// A mask determining what is ground to the character
	[SerializeField] private Transform m_GroundCheck;							// A position marking where to check if the player is grounded.
	const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
	public bool m_Grounded;            // Whether or not the player is grounded.
	const float k_CeilingRadius = .2f; // Radius of the overlap circle to determine if the player can stand up
	public Rigidbody2D m_Rigidbody2D;
	private bool m_FacingRight = true;  // For determining which way the player is currently facing.
	private Vector3 m_Velocity = Vector3.zero;
	public Animator animator;

	[Header("Events")]
	[Space]

	public UnityEvent OnLandEvent;
	private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();

		if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();
	}

	private void FixedUpdate()
	{
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
	}


	public void Move(float move, bool jump)
	{
		if (m_Grounded || m_AirControl) 		//only control the player if grounded or airControl is turned on
		{
			Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y); 		// Move the character by finding the target velocity
			m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing); 	// And then smoothing it out and applying it to the character

			if (move > 0 && !m_FacingRight) 			// If the input is moving the player right and the player is facing left...
			{
				Flip();
			}
			else if (move < 0 && m_FacingRight) 		// Otherwise if the input is moving the player left and the player is facing right...
			{
				Flip();
			}
		}
		if (m_Grounded && jump) 		// If the player should jump...
		{
			m_Grounded = true; 			// Add a vertical force to the player.
			m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce)); 
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
		m_FacingRight = !m_FacingRight; 		// Switch the way the player is labelled as facing.
		Vector3 theScale = transform.localScale;  	// Multiply the player's x local scale by -1.
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}