using System.Collections;
using System.Collections.Generic; //BIADA TYM KTORZY SPROBUJA TEN KOD ZROZUMIEC!!! 
using UnityEngine;                //BIADA POWIADAM!!
using UnityEngine.UI;             //BIADA!

public class Healthmanager : MonoBehaviour
{
    [SerializeField] private float PoczatkoweZycie;
    public float health;
    public Image[] hearts;
    public Sprite pelneserce;
    public Sprite pusteserce;
    public bool enemyIsClose;
    [SerializeField] private float niesmiertelnosc;
    [SerializeField] private float lflashy;
    [SerializeField] private float damage;
    private SpriteRenderer spriteRend;
    
    void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
        
    }
    private void Awake()
    {
        health = PoczatkoweZycie;

    }
    public void TakeDamage(float _damage)
    {
        health = Mathf.Clamp(health - _damage,0,PoczatkoweZycie);
        if(health>0)
        {
            StartCoroutine(Niesmiertelnosc());


        }
    }

    


    void Update()
    {
        foreach(Image img in hearts)
        {
            img.sprite = pusteserce;
        }
        for (int i=0; i<health;i++)
        {
            hearts[i].sprite = pelneserce;
        }
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Enemy")
        {
            TakeDamage(damage);
        }
    }
    private IEnumerator Niesmiertelnosc()
    {
        Physics2D.IgnoreLayerCollision(10,11, true);
        for(int i =0; i<lflashy; i++)
        {
            spriteRend.color= new Color(1,0,0,0.5f);
            yield return new WaitForSeconds(niesmiertelnosc/(lflashy*2 ));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(niesmiertelnosc/(lflashy*2 ));
        }
        Physics2D.IgnoreLayerCollision(10,11, false);


    } 

    
}
