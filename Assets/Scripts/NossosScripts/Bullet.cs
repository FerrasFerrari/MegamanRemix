using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public float force;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnParticleCollision(GameObject other)
    {
        Destroy(gameObject);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        bool n = collision.gameObject == gameObject;
        Debug.Log(collision.gameObject + " / " + n);
        if (collision.gameObject != gameObject)
        {
            Destroy(gameObject);
        }
    }
}
