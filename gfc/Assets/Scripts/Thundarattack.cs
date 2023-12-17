using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thundarattack : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetBool("attack", true);
        }
        else
        {
            animator.SetBool("attack", false);
        }
    }
}
