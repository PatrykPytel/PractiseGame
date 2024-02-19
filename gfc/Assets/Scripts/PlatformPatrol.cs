using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPatrol : MonoBehaviour
{
    public Rigidbody2D rb;
    //private Transform currentPoint;
    private int zmienkierunek=1;
    public float predkosc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(zmienkierunek==1) { 
            rb.velocity = new Vector2(predkosc, 0);
        }else { 
            rb.velocity = new Vector2(-predkosc, 0);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D coll) { 
        if(coll.tag == "Point") { 
            zmienkierunek*=-1;
        }
        }
    private void OnCollisionEnter2D(Collision2D coll) { 
        coll.transform.SetParent(transform);
    }
    private void OnCollisionExit2D(Collision2D coll) {
        coll.transform.SetParent(null);
    }
}
