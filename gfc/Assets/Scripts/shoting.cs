using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoting : MonoBehaviour
{
    public bool shooting= false;
  //  public Rigidbody2D rb;
  //  public float speed;
  //  public LayerMask whatstopsyou;
    public float damage=0.5f;
 //   [SerializeField] private GameObject spritecol;

    //private Vector3 offset = new Vector3(0f, 0f,-10f);
    //private float smoothTime = 0.25f;
    //private Vector3 velocity = Vector3.zero;
    [SerializeField] private Transform target;
//    [SerializeField] private Finalmovement player;
    private float cooldown = 0.5f;
    private float restartcooldown;
    
    public GameObject bullet;
    public Transform firePoint;
    public float bulletSpeed = 10f;
   
    float lookAngle;
    Vector2 lookDirection;
    // Start is called before the first frame update
    void Start()
    {
        restartcooldown = cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        lookDirection= Camera.main.WorldToScreenPoint(Input.mousePosition);
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x);
        lookDirection = new Vector2(lookDirection.x - transform.position.x, lookDirection.y - transform.position.y);
        firePoint.rotation = Quaternion.Euler(0, 0, lookAngle);
      //  Transform();
        if(Input.GetKeyDown(KeyCode.Z) && cooldown <= 0 ) { 
            cooldown = restartcooldown;
         //   transform.position = target.position;
          //  spritecol.SetActive(true);
            Shot();
        }else { 
            cooldown -= Time.deltaTime;
        }
        
    }
    private void Shot() {
        GameObject bulletClone = Instantiate(bullet);
        bulletClone.transform.position = firePoint.position;
        bulletClone.transform.rotation = Quaternion.Euler(0, 0, lookAngle);
        bulletClone.GetComponent<Rigidbody2D>().velocity = firePoint.right * bulletSpeed;
       // shooting = true;
    }
  //  private void Transform() { 
  //      if(shooting==false) { 
  //          transform.position = target.position; 
         //   spritecol.SetActive(false);
  //      }
//    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
     //   if(collision.tag == "Wall") {
     //       shooting =false;
       // }
        if(collision.GetComponent<Hpwrogow>() != null) {
            collision.GetComponent<Hpwrogow>().mhp -=damage;
            shooting =false;
        }
    }
}
