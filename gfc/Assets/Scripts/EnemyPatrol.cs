using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
        // Start is called before the first frame update
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb;
    private Transform currentPoint;
    private Animator anim;
    public float speed;
    private bool isattacked=false;
    private float JumpForce = 2f;
    private int scale =1;
    private bool grounded;
    [SerializeField] private Transform m_GroundCheck;
    [SerializeField] private LayerMask m_WhatIsGround;
    const float k_GroundedRadius = .2f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
        currentPoint =pointB.transform;
        //anim.SetBool("isRunning", true);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if(grounded) { 
            if(currentPoint==pointB.transform)
            {
                rb.velocity = new Vector2(-speed, 0);
            }else
            {
                rb.velocity = new Vector2(speed,0);
            }
        }
        if(isattacked && scale == 1) { 
            rb.velocity = new Vector2(8f, JumpForce);
            Invoke("stopknockback",0.5f);
          //  rb.velocity = new Vector2(-speed,0);
        } else if(isattacked && scale ==-1){ 
            rb.velocity = new Vector2(-8f, JumpForce);
            Invoke("stopknockback",0.5f);
           // rb.velocity = new Vector2(speed, 0);
        }
        if (Vector2.Distance(transform.position, currentPoint.position)<0.5f && currentPoint==pointB.transform)
        {
            currentPoint=pointA.transform;
            Flip();

        }
        if (Vector2.Distance(transform.position, currentPoint.position)<0.5f && currentPoint==pointA.transform)
        {
            currentPoint=pointB.transform;
            Flip();
            
        }

    }
    private void FixedUpdate()
	{
       // Move(horizontalMove * Time.fixedDeltaTime, jump);
	 //  rb.velocity = new Vector2(horizontalMove * runSpeed, rb.velocity.y);
       // jump= false;

		bool wasGrounded = grounded;
		grounded = false;
		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);	// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		for (int i = 0; i < colliders.Length; i++) // This can be done using layers instead but Sample Assets will not overwrite your project settings.
		{
			if (colliders[i].gameObject != gameObject)
			{
				grounded = true;
			}
		}
	}
    private void Flip()
	{
		

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
        scale *= -1;
	}
    public void Knockback() { 
//       rb.velocity = new Vector2(10f, JumpForce);
        isattacked = true;
        //rb.constraints = RigidbodyConstraints2D.None;
       // Debug.Log("sDad");
    }
    void stopknockback() { 
        isattacked = false;
    }

}