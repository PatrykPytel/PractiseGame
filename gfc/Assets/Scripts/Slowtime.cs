using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Slowtime : MonoBehaviour
{
    private float cooldown;
    public Transform target;
    Finalmovement move;
    Rigidbody2D rb;
    private bool timeslowed = false;
    Image Background;
    // Start is called before the first frame update
    void Start()
    {
        move= GameObject.Find("Player").GetComponent<Finalmovement>();
        Background = GameObject.Find("Background").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime; 
        if(cooldown <= 0 && timeslowed && move.m_Grounded)
        {
            Time.timeScale = 1f;
            move.runSpeed = move.startspeed;
            move.m_JumpForce = move.startjumpforce;
            move.rb.gravityScale = 3f;
            timeslowed = false ;
            Background.color = new Color(0,0,0,0f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Time.timeScale = 0.5f;
            cooldown = 10;
            transform.position = target.position;
            move.runSpeed = move.doublespeed;
            move.rb.gravityScale = 10f;
            move.m_JumpForce = move.slowedjumpforce;
            timeslowed = true;
            Background.color = new Color(0,0,1,0.5f);
        }
    }
}
