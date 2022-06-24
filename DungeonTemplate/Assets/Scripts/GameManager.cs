using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private int gems = 0;
    private int savedGems = 0;
    [SerializeField] int health = 100;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    public int GetGems()
    {
        return gems;
    }

    public void AddGems(int amount)
    {
        gems += amount;
    }

    public int GetHealth()
    {
        return health;
    }

    public void ReduceHealth(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            health = 100;
            gems = savedGems;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public void SaveGems()
    {
        savedGems = gems;
    }
}
