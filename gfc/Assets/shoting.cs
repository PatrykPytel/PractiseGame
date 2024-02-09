using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoting : MonoBehaviour
{
    public bool shooting= false;
    public Rigidbody2D rb;
    public float speed;

    //private Vector3 offset = new Vector3(0f, 0f,-10f);
    //private float smoothTime = 0.25f;
    //private Vector3 velocity = Vector3.zero;
    [SerializeField] private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(shooting) { 
            rb.velocity = new Vector2(speed,0);
        }else { 
            transform.position = target.position;
        }
    }
    public void Shot() { 
        shooting = true;
    }
}
