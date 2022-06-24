using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    [SerializeField] Text gemsText;
    [SerializeField] Slider healthBar;
    [SerializeField] Slider sanityBar;
    [SerializeField] Slider fuelBar;
    [SerializeField] GameObject winPanel;

    void Update()
    {
        //gemsText.text = "GEMS: " + GameManager.Instance.GetGems();

        healthBar.value = GameManager.Instance.GetHealth();
        sanityBar.value = GameManager.Instance.GetSanity();
        fuelBar.value = GameManager.Instance.GetFuel();

        if (GameManager.Instance.CheckVictory() == true)
        {
            Time.timeScale = 0f;
            winPanel.SetActive(true);
        }
    }
}
