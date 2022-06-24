using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoalBehavior : MonoBehaviour
{
    bool respawning = false;
    [SerializeField] float respawnTime = 20;
    float timer = 0;
    
    void Update()
    {
        if (respawning)
        {
            timer += Time.deltaTime;

            if (timer >= respawnTime)
            {
                timer = 0;
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
                gameObject.GetComponent<CircleCollider2D>().enabled = true;
            }
        }
    }

    public void Respawner()
    {
        respawning = true;
    }
}
