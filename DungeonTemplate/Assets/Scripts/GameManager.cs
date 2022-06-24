using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] int health = 100;
    [SerializeField] int fuel = 100;
    [SerializeField] int sanity = 100;
    [SerializeField] int fires = 0;
    [SerializeField] bool win = false;
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

    void Update()
    {
        if (health > 100)
        {
            health = 100;
        }

        if (sanity > 100)
        {
            sanity = 100;
        }

        if (fuel > 100)
        {
            fuel = 100;
        }

        if (sanity < 0)
        {
            sanity = 0;
        }

        if (fuel < 0)
        {
            fuel = 0;
        }

        if (fires == 5)
        {
            win = true;
        }
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
            ResetLevel();
        }
    }

    public void ResetLevel()
    {
        health = 100;
        sanity = 100;
        fuel = 100;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public int GetFuel()
    {
        return fuel;
    }

    public int GetSanity()
    {
        return sanity;
    }

    public void ReduceFuel(int amount)
    {
        fuel -= amount;
    }

    public void ReduceSanity(int amount)
    {
        sanity -= amount;
    }

    public void AddFuel(int amount)
    {
        fuel += amount;
    }

    public void AddSanity(int amount)
    {
        sanity += amount;
    }

    public void LightFire()
    {
        fires++;
    }

    public bool CheckVictory()
    {
        return win;
    }
}
