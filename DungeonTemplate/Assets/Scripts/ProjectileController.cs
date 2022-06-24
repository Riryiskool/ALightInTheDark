using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] int damage = 10;
    [SerializeField] float speed = 10f;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void SetVelocity(Vector2 velocity)
    {
        rb.velocity = velocity * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyController>().TakeDamage(damage);
            Destroy(this.gameObject);
        }
        if (collision.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }
    }
}
