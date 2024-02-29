using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] Hpwrogow hp;
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
        previoushp = hp.mhp;
        rb= GetComponent<Rigidbody2D>();
    }
    public void monsterhurt()
    {
        Monster.GetComponent<EnemyPatrol>().Speedfreeze();
    }
    public void monsterattacked() { 
        Monster.GetComponent<EnemyPatrol>().Knockback();
    }   
    void Update()
    {
        if(hp.mhp<=0) {
            animator.SetBool("isdead", true);
            rb.simulated = false;
            Invoke("monsterdead", dyinganim);
        }
        else if(hp.mhp<previoushp) {
            if(hp.mhp==previoushp) { 
                monsterattacked();
            }else if(hp.mhp+4==previoushp) { 
                monsterhurt();
            }
            animator.SetBool("strucked", true);
            previoushp = hp.mhp;
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
             //   if(hp.mhp==previoushp) { 
        //        monsterattacked();
         //   }else if(hp.mhp+4==previoushp) { 
        //        monsterhurt();
          //  }