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
        if(currentPoint==pointB.transform)
        {
            rb.velocity = new Vector2(-speed, 0);
        }else
        {
           //Knockback(); 
           // rb.velocity = new Vector2(10f, JumpForce);
            rb.velocity = new Vector2(speed,0);
        }
        if(isattacked && scale == 1) { 
            rb.velocity = new Vector2(10f, JumpForce);
//./Invoke("stopknockback",1f);
        } else if(isattacked && scale ==-1){ 
            rb.velocity = new Vector2(-10f, JumpForce);
           // Invoke("stopknockback",1f);
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