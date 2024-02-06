using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float mhp;
    public GameObject Monster;
    public Animator animator;
    private float previoushp;
    private bool die;
    public float dyinganim;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    // Update is called once per frame
    void Start() 
    {
        previoushp = mhp;
        rb= GetComponent<Rigidbody2D>();
    }
    public void monsterhurt()
    {
        mhp -=2;
    }
    public void monsterattacked() { 
        mhp -=1;
        Monster.GetComponent<EnemyPatrol>().Knockback();
    }
    void Update()
    {
        if(mhp<=0) {
            animator.SetBool("isdead", true);
            rb.simulated = false;
            Invoke("monsterdead", dyinganim);
        }
        else if(mhp<previoushp) {
            animator.SetBool("strucked", true);
            previoushp = mhp;
        }
        else { 
            animator.SetBool("strucked", false);
        }

    }
    void monsterdead() {
        Destroy(Monster);
    }     
}
//        if (health<=0) 
    //    {
          //  animator.SetBool("strucked", true);//
    //    } //