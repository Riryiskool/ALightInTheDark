using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayOnPlayer : MonoBehaviour
{
    public GameObject player;

    void Update()
    {
        gameObject.transform.position = player.transform.position;
    }
}
