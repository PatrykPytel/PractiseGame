using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
  //  private float timeBtwAttack;
    public Animator animator;
    //public  float startTimeBtwAttack;
   // public Transform attackPos;
   // public float attackRange;
    public LayerMask whatisEnemies;
    public bool enemyIsClose;
    public GameObject Monster;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //if(timeBtwAttack <=0)
       // {
         //   if(Input.GetKey(KeyCode.E))
           // {
             //   animator.SetBool("Isattacking", true);
               // Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position,attackRange,whatisEnemies );
            //    for (int i = 0; i < enemiesToDamage.Length;i++)
            ///    {
                   
            //        Destroy(enemiesToDamage[i].gameObject);
                    
                    
            //    }

            //}
            //else if(Input.GetKeyUp(KeyCode.E))
            //{
             //   animator.SetBool("Isattacking", false);
            //}
            //timeBtwAttack = startTimeBtwAttack;
            
        //}
        //else
        //{
          //  timeBtwAttack -=Time.deltaTime;
            
        
       // }
      if (enemyIsClose==true)
      {


        if(Input.GetKeyDown(KeyCode.Mouse0))
        {

          
          Debug.Log("MOuse");
          animator.SetBool("Isattacking", true);
          Destroy(Monster);
        }
          

      }
      else
      {
        animator.SetBool("Isattacking", false);
      }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {


        
            enemyIsClose = true;


        }
        else
        {
            enemyIsClose = false;
        }

    }
    
}