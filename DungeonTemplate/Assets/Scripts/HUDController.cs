using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUDController : MonoBehaviour
{
    [SerializeField] Text gemsText;
    [SerializeField] Slider healthBar;
    [SerializeField] Slider sanityBar;
    [SerializeField] Slider fuelBar;
    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject losePanel;

    void Update()
    {
        //gemsText.text = "GEMS: " + GameManager.Instance.GetGems();

        healthBar.value = GameManager.Instance.GetHealth();
        sanityBar.value = GameManager.Instance.GetSanity();
        fuelBar.value = GameManager.Instance.GetFuel();

        if (GameManager.Instance.CheckLoss() == true)
        {
            Time.timeScale = 0f;
            losePanel.SetActive(true);
        }

        if (GameManager.Instance.CheckVictory() == true)
        {
            Time.timeScale = 0f;
            winPanel.SetActive(true);
        }

    }

    public void Quit()
    {
        Debug.Log("Quit Game!");
        Application.Quit();
    }

    public void Reload()
    {

        Time.timeScale = 1f;
        losePanel.SetActive(false);
        GameManager.Instance.ResetLevel();
    }
}
