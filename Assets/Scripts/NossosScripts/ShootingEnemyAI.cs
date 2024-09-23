using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ShootingEnemyAI : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    private float timer;
    private GameObject jogador;
    private float distancia;
    public float bulletForce;
    public float yOffset = 5;
    public float shootDelay = 2;
    public Animator animator;
    public float attackRange = 8.5f;
    bool isShooting = false;
    
    // Start is called before the first frame update
    void Start()
    {
        jogador = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (jogador != null)
        {
            distancia = Vector2.Distance(transform.position, jogador.transform.position);
            Vector2 direction = (jogador.transform.position + new Vector3(0, yOffset, 0)) - transform.position;
            direction.Normalize();
            FlipX(direction);
            if (distancia < attackRange)
            {
                timer += Time.deltaTime;
                isShooting = false;
                animator.SetBool("isShooting", isShooting);
                if (timer > shootDelay && !isShooting)
                {
                    isShooting = true;
                    animator.SetBool("isShooting", isShooting);
                    timer = 0;
                    StartCoroutine(ShootWithDelay());
                }
                
            }
        }
        else
        {
            jogador = GameObject.FindWithTag("Player");
        }


    }
    void shoot()
    {
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.force = bulletForce;
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
    private IEnumerator ShootWithDelay(){
        yield return new WaitForSeconds(1f);
        timer = 0;
        shoot();
    }

    void FlipX(Vector2 direction){
        transform.localScale = new Vector3(Mathf.Sign(direction.x), transform.localScale.y, 
        transform.localScale.z);

        bulletPos.position = new Vector3(Mathf.Sign(direction.x) * bulletPos.position.x, 
        bulletPos.position.y, bulletPos.position.z);
    }
    // float RoundAwayFromZero(float n){
    //     float nF = MathF.Round(n, MidpointRounding.AwayFromZero);
    //     if(nF != 0){
    //         return nF;
    //     }else{
    //         return -1;
    //     }
    // }
}
