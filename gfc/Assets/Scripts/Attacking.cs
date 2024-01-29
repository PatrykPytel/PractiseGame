using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour
{
    public Animator animator;
    public Transform attackPos;
    public float attackRange;
    public LayerMask whatisEnemies;
    public bool enemyIsClose;
    public GameObject Monster;

    // Start is called before the first frame update
    void Start() {
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) ) 
        {
            animator.SetBool("Isattacking", true);
            Collider2D[]enemiesToDamage=Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatisEnemies);
            for (int i = 0; i < enemiesToDamage.Length; i++)
            {   
                Monster.GetComponent<EnemyHealth>().monsterhurt();
            }
        }
        else
        {
            animator.SetBool("Isattacking", false);
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

}
