using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    float interval = .5f;
    float timer = 0f;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            timer += Time.deltaTime;

            if (timer >= interval)
            {
                GameManager.Instance.AddSanity(20);
                timer = 0f;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            timer = 0f;
        }
    }
}
