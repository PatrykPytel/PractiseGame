using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Slowtime : MonoBehaviour
{
    private float cooldown;
    public Transform target;
    Finalmovement move;
    Rigidbody2D rb;
    private bool timeslowed = false;
    // Start is called before the first frame update
    void Start()
    {
        move= GameObject.Find("Player").GetComponent<Finalmovement>();
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime; 
        if(cooldown <= 0 && timeslowed)
        {
            Time.timeScale = 1f;
            move.runSpeed = move.startspeed;
            move.m_JumpForce = move.startjumpforce;
            move.rb.gravityScale = 3f;
            timeslowed = false ;

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
            move.rb.gravityScale = 6f;
            move.m_JumpForce = move.slowedjumpforce;
            timeslowed = true;
        }
    }
}
