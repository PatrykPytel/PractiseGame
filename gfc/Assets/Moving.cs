using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.W) )
        {
            rb.velocity=  new Vector2(0f,1000f);

        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            rb.velocity=  new Vector2(-500f,0f);

        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            rb.velocity=  new Vector2(500f,0f);

        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            rb.velocity=  new Vector2(0f,-1000f);

        }
             
        
    }
}
