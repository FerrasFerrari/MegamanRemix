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
    
    // Start is called before the first frame update
    void Start()
    {
        jogador = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (jogador != null)
        {
            distancia = Vector2.Distance(transform.position, jogador.transform.position);
            Vector2 direction = jogador.transform.position - transform.position;
            direction.Normalize();
            FlipX(direction);
            if (distancia < 10)
            {
                timer += Time.deltaTime;
                
                if (timer > 2)
                {
                    timer = 0;
                    shoot();
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

    void FlipX(Vector2 direction){
        transform.localScale = new Vector3(RoundAwayFromZero(direction.x), transform.localScale.y, 
        transform.localScale.z);

        bulletPos.position = new Vector3(RoundAwayFromZero(direction.x) * bulletPos.position.x, 
        bulletPos.position.y, bulletPos.position.z);
    }
    float RoundAwayFromZero(float n){
        float nF = MathF.Round(n, MidpointRounding.AwayFromZero);
        if(nF != 0){
            return nF;
        }else{
            return -1;
        }
    }
}
