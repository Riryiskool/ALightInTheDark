using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    [SerializeField] Text gemsText;
    [SerializeField] Text healthText;
    void Update()
    {
        gemsText.text = "GEMS: " + GameManager.Instance.GetGems();
        healthText.text = "HEALTH: " + GameManager.Instance.GetHealth();

    }
}
