using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour
{
    public GameObject player;
    public Animator animator;
    public Transform attackPos;
    public float attackRange;
    public LayerMask whatisEnemies;
    public bool enemyIsClose;
    public GameObject Monster;
    public float cooldown;
    public float timepassed=0;
    public float time;
    public float attackduration;

    // Start is called before the first frame update
    void Stopmovement() { 
        player.GetComponent<Finalmovement>().Startmoving();
    }
     void Update()
    {
        if (timepassed <= 0) {      
            if(Input.GetKeyDown(KeyCode.Q) ) 
            {
                player.GetComponent<Finalmovement>().Stopmoving();
                timepassed = cooldown;
                animator.SetBool("Isattacking", true);
                Collider2D[]enemiesToDamage=Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatisEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {   
                    Monster.GetComponent<EnemyHealth>().monsterhurt();
                }
                Invoke("Stopmovement", attackduration); 
            }
        }
        else
        {
            animator.SetBool("Isattacking", false);
            timepassed -=  Time.deltaTime;
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

}
