using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicattack : MonoBehaviour
{
    public Animator animator;
    private float comboTime =1f;
	private float comboCounter;
    private float cooldown;
    public Transform attackPos;
    public float attackRange;
    public LayerMask whatisEnemies;
  //  public bool enemyIsClose;
    public GameObject Monster;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(cooldown<=0f) { 
            if(Input.GetKeyDown(KeyCode.Mouse0) && comboCounter>0f) {
                animator.SetBool("2attack", true);
                comboCounter = 0f;
                cooldown =  1f;
                Attack();
            } else if(Input.GetKeyDown(KeyCode.Mouse0)) { 
                animator.SetBool("isattacking", true);
                comboCounter = comboTime;
                Attack();
            }
            else { 
                comboCounter-=Time.deltaTime;
                animator.SetBool("isattacking", false);
                animator.SetBool("2attack",false);
            } 
        } else { 
            cooldown -= Time.deltaTime;
            comboCounter-=Time.deltaTime;
            animator.SetBool("isattacking", false);
            animator.SetBool("2attack",false);
        }
        
    }
    void Attack() { 
        Collider2D[]enemiesToDamage=Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatisEnemies);
        for (int i = 0; i < enemiesToDamage.Length; i++)
        {   
            Monster.GetComponent<EnemyHealth>().monsterattacked();
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
