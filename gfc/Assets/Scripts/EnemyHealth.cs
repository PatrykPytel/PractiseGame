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
    // Start is called before the first frame update
    // Update is called once per frame
    void Start() 
    {
        previoushp = mhp;
    }
    public void monsterhurt()
    {
        mhp -=1;
    }
    void Update()
    {
        if(mhp<=0) {
            animator.SetBool("isdead", true);
            Destroy(Monster);
        }
        else if(mhp<previoushp) {
            animator.SetBool("strucked", true);
            previoushp = mhp;
        }
        else { 
            animator.SetBool("strucked", false);
        }

    }     
}
//        if (health<=0) 
    //    {
          //  animator.SetBool("strucked", true);//
    //    } //