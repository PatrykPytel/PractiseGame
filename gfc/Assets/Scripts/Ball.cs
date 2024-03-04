using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = new Vector2(speed,0f);
      //  rb.velocity = new Vector2(0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(speed,0f);
     //  Invoke("startspeed", 2f);
        //rb.velocity = new Vector2(0f, 0f);
        //Invoke("stopspeed", 2f);
    }
    void startspeed() { 
        rb.velocity = new Vector2(speed,0f);
    }
    void stopspeed() { 
        rb.velocity = new Vector2(0f, 0f);
    }
}
