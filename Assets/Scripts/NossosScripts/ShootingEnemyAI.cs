using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemyAI : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    private float timer;
    private GameObject jogador;
    private float distancia;
    
    // Start is called before the first frame update
    void Start()
    {
        jogador = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(distancia);
        if (jogador != null)
        {
            distancia = Vector2.Distance(transform.position, jogador.transform.position);
            Vector2 direction = jogador.transform.position - transform.position;
            direction.Normalize();
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
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}
