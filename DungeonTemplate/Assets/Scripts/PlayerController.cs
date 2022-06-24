using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 7f;
    [SerializeField] GameObject projectile;
    [SerializeField] float attackInterval = 0.5f;

    Rigidbody2D rb;
    Animator animator;
    float attackTimer = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(speed, 0);
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-speed, 0);
        }

        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector2(0, speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector2(0, -speed);
        }

        if (!(Input.GetKey(KeyCode.D)
        || Input.GetKey(KeyCode.A)
        || Input.GetKey(KeyCode.W)
        || Input.GetKey(KeyCode.S)))
        {
            rb.velocity = new Vector2(0, 0);
        }
        animator.SetFloat("Horizontal", rb.velocity.x);
        animator.SetFloat("Vertical", rb.velocity.y);

        if (attackTimer <= 0)
        {
            Attack();
        }
        else
        {
            attackTimer -= Time.deltaTime;
        }
    }
    private void Attack()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            SpawnProjectile(Vector2.up);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            SpawnProjectile(Vector2.down);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            SpawnProjectile(Vector2.left);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            SpawnProjectile(Vector2.right);
        }
    }
    private void SpawnProjectile(Vector2 direction)
    {
        GameObject instance = Instantiate(projectile, transform.position, Quaternion.identity);
        instance.GetComponent<ProjectileController>().SetVelocity(direction);
        attackTimer = attackInterval;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Gem"))
        {
            GameManager.Instance.AddGems(1);
            Destroy(collision.gameObject);
        }
    }
}
