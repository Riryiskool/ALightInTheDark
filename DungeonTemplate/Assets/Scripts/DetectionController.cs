using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class DetectionController : MonoBehaviour
{
    [SerializeField] GameObject enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enemy.GetComponent<AIPath>().enabled = true;
        }
    }
}
