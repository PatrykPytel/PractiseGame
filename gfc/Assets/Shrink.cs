using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Shrink : MonoBehaviour
{
    public GameObject small; 
    public Transform target;
    private float cooldown;
    // Start is called before the first frame update
    void Start()
    {
       // small = GetComponent<Transform>();
        //backgroundBox.LeanScale(Vector3.one, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;
        if (cooldown <= 0)
        {
            small.transform.localScale = new Vector3(1f, 1f, 1.0f);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            small.transform.localScale = new Vector3(0.5f,0.5f,1.0f);
            cooldown = 10;
            transform.position = target.position;
        }
    }
}
