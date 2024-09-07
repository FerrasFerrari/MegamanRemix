using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int vida;
    // Start is called before the first frame update
    void Start()
    {
        vida = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnParticleCollision(GameObject other)
    {
        vida = vida - 1;
        if(vida <= 0)
        {
            Destroy(gameObject);
        }
    }
}
