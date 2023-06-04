using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour
{
    private float timeBtwAttack;
    public Animator animator;
    public  float startTimeBtwAttack;
    public Transform attackPos;
    public float attackRange;
    public LayerMask whatisEnemies;
    public bool enemyIsClose;
    public GameObject Monster;
    // Start is called before the first frame update
    void Update()
    {

        if(timeBtwAttack<=0)
        {
            timeBtwAttack=startTimeBtwAttack;
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                animator.SetBool("Isattacking", true);
                
                Collider2D[]enemiesToDamage=Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatisEnemies);
                Debug.Log("Atak");
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    Destroy(Monster);
                }



            }
            else if(Input.GetKeyUp(KeyCode.Mouse0))
            {

            }

        }
        else
        {
            timeBtwAttack -= 1;
            animator.SetBool("Isattacking", false);

        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

}
