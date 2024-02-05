using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicattack : MonoBehaviour
{
    public Animator animator;
    private float comboTime =1f;
	private float comboCounter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && comboCounter>0f) {
            animator.SetBool("2attack", true);
            comboCounter = -1f;
        } else if(Input.GetKeyDown(KeyCode.Mouse0)) { 
            animator.SetBool("isattacking", true);
            comboCounter = comboTime;
        }
        else { 
            comboCounter-=Time.deltaTime;
            animator.SetBool("isattacking", false);
            animator.SetBool("2attack",false);
        }
        
    }
}
