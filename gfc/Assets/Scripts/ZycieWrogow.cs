using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZycieWrogow : MonoBehaviour
{
    [SerializeField] private Hpwrogow hp;
    public GameObject Monster;
   // public Animator animator;
    private float previoushp;
    private bool die;
   // public float dyinganim;
    //private Rigidbody2D rb;
    // Start is called before the first frahp.me update
    void Start()
    {
        previoushp = hp.mhp;
    }

    // Update is called once per frame
    void Update()
    {
        if(hp.mhp<=0) {
          //  animator.SetBool("isdead", true);
           // rb.simulated = false;
           monsterdead();
            //Invoke("monsterdead", dyinganim);
        }
        else if(hp.mhp<previoushp) {
          //  animator.SetBool("strucked", true);
            previoushp = hp.mhp;
        }
     //   else { 
          //  animator.SetBool("strucked", false);
     //   }

    }
    void monsterdead() {
        Destroy(Monster);
    } 
}
