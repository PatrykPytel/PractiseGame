using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicattack : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0)) {
            animator.SetBool("isattacking", true);

        }else { 
            animator.SetBool("isattacking", false);
        }
        
    }
}
