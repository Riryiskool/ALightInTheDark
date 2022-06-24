using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 7f;
    [SerializeField] GameObject projectile;
    [SerializeField] float attackInterval = 0.5f;
    [SerializeField] GameObject witch;
    [SerializeField] GameObject torch;

    Rigidbody2D rb;
    //Animator animator;
    float attackTimer = 0;
    public bool inLight;
    bool torchOn;

    float sanityReductionTimer = 0f;
    [SerializeField] float sanityTimer = .5f;

    float fuelReductionTimer = 0f;
    [SerializeField] float fuelTimer = .5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
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
        //animator.SetFloat("Horizontal", rb.velocity.x);
        //animator.SetFloat("Vertical", rb.velocity.y);

        if (attackTimer <= 0)
        {
            Attack();
        }
        else
        {
            attackTimer -= Time.deltaTime;
        }

        
        if (!inLight)
        {
            CancelInvoke("SanityAdd");
            sanityReductionTimer += Time.deltaTime;

            if (sanityReductionTimer >= sanityTimer)
            {
                GameManager.Instance.ReduceSanity(3);
                sanityReductionTimer = 0f;
            }
        }
        else
        {
            sanityReductionTimer = 0f;
        }
        
        if (GameManager.Instance.GetSanity() == 0)
        {
            witch.SetActive(true);
            witch.GetComponent<AudioSource>().enabled = true;
        }

        if (GameManager.Instance.GetFuel() == 0)
        {
            torch.SetActive(false);
        }
        else
        {
            torch.SetActive(true);
            torch.GetComponent<CircleCollider2D>().enabled = true;
        }

        fuelReductionTimer += Time.deltaTime;

        if (fuelReductionTimer >= fuelTimer)
        {
            fuelReductionTimer = 0f;
            GameManager.Instance.ReduceFuel(5);
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
        /*
        if (collision.CompareTag("Gem"))
        {
            GameManager.Instance.AddGems(1);
            Destroy(collision.gameObject);
        }
        */

        if (collision.CompareTag("Light"))
        {
            inLight = true;
            InvokeRepeating("SanityAdd", .25f, .25f);

        }

        if (collision.CompareTag("Torch"))
        {
            inLight = true;
            torchOn = true;
            InvokeRepeating("SanityAdd", .25f, .25f);

        }

        if (collision.CompareTag("Coal"))
        {
            GameManager.Instance.AddFuel(30);
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            collision.gameObject.GetComponent<CircleCollider2D>().enabled = false;
            collision.gameObject.GetComponent<CoalBehavior>().Respawner();
        }

        
        if (collision.CompareTag("Fire"))
        {
            GameManager.Instance.LightFire();
            collision.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
        }
        
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Light"))
        {
            if (!torchOn)
            {
                inLight = false;
            }
        }

        if (collision.CompareTag("Torch"))
        {
            inLight = false;
            torchOn = false;
            collision.gameObject.GetComponent<CircleCollider2D>().enabled = false;
        }
        
    }

    // This is only here because Unity is kinda dumb and won't let you put in functions directly into InvokeRepeating >:(
    private void SanityAdd()
    {
        GameManager.Instance.AddSanity(3);
    }

}
