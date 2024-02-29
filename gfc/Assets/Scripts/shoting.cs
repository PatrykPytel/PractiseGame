using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoting : MonoBehaviour
{
    public bool shooting= false;
    public Rigidbody2D rb;
    public float speed;
  //  public LayerMask whatstopsyou;
    public float damage=0.5f;
    [SerializeField] private GameObject spritecol;

    //private Vector3 offset = new Vector3(0f, 0f,-10f);
    //private float smoothTime = 0.25f;
    //private Vector3 velocity = Vector3.zero;
    [SerializeField] private Transform target;
    [SerializeField] private Finalmovement player;
    private float cooldown = 2f;
    private float restartcooldown;
    // Start is called before the first frame update
    void Start()
    {
        restartcooldown = cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        Transform();
        if(Input.GetKeyDown(KeyCode.Z) && cooldown <= 0 ) { 
            cooldown = restartcooldown;
            transform.position = target.position;
            spritecol.SetActive(true);
            Shot();
        }else { 
            cooldown -= Time.deltaTime;
        }
        
    }
    private void Shot() { 
            rb.velocity = new Vector2(speed*player.playerscale,0);
            shooting = true;
    }
    private void Transform() { 
        if(shooting==false) { 
            transform.position = target.position; 
            spritecol.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Wall") {
            shooting =false;
        }
        if(collision.GetComponent<Hpwrogow>() != null) {
            collision.GetComponent<Hpwrogow>().mhp -=damage;
            shooting =false;
        }
    }
}
