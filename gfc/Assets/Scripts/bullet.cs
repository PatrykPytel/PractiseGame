using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform target;
    private float cooldown = 1.5f;
    private float restartcooldown;
    private float flytime = 2f;
   // private float restartflytime;
    public float xspeed;
    public float yspeed;
    // Start is called before the first frame update
    void Start() {
        restartcooldown = cooldown;
   //     restartflytime = flytime;
     }

    // Update is called once per frame
    void Update()
    {
        if (cooldown <= 0) { 
            rb.velocity = new Vector2(xspeed,yspeed);
            cooldown = restartcooldown;
            Invoke("Bulletdestroy", flytime);
        }else { 
            cooldown -= Time.deltaTime;
        } 
    }
    private void Bulletdestroy()  { 
        transform.position = target.position;
    }
}
