using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject player;
    private float distancia;
    public float speed;
    public Animator animator;
    public float yOffset = 0.4f;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody2D>();   
        animator = GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null){
            distancia = Vector2.Distance(transform.position, player.transform.position);
            Vector2 direction = player.transform.position - transform.position;
            direction.Normalize();
            if(distancia < 4)
            {
                animator.SetBool("HasXVelocity", true);
                transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position + new Vector3(0, yOffset, 0), speed * Time.deltaTime);
            }else{
                animator.SetBool("HasXVelocity", false); 
            }
        }else{
            rb.velocity = new Vector2(0, rb.velocity.y);
            
            player = GameObject.FindWithTag("Player");
        }
        
    }
    private void LateUpdate() {
        FlipX();     
    }
    void FlipX(){
        transform.localScale = new Vector3(-Mathf.Sign(rb.velocity.x), transform.localScale.y, 
        transform.localScale.z);
    }
}
