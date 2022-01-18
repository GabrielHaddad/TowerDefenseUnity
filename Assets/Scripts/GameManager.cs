using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] int levelHealth = 100;
    [SerializeField] TextMeshProUGUI lifeText;
    [SerializeField] TextMeshProUGUI waveText;
    [SerializeField] TextMeshProUGUI moneyText;
    [SerializeField] TextMeshProUGUI gameOverText;
    EnemySpawner enemySpawner;
    UIController uIController;
    int money = 1000;

    void Awake() 
    {   
        enemySpawner = FindObjectOfType<EnemySpawner>();
        uIController = FindObjectOfType<UIController>();
    }

    void Start() 
    {
        lifeText.text = "Life: " + levelHealth.ToString();
        moneyText.text = "Money: " + money;
        waveText.text = "Wave: " + enemySpawner.GetCurrentWaveCount() +
                                     "/" + enemySpawner.GetTotalWavesCount();
    }

    void Update() 
    {
        moneyText.text = "Money: " + money;
        waveText.text = "Wave: " + enemySpawner.GetCurrentWaveCount() +
                                     "/" + enemySpawner.GetTotalWavesCount();

        if (levelHealth <= 0)
        {
            EndGame("Better Luck Next Time!\n You Lose!");
        }
        else if (enemySpawner.GetCurrentWaveCount() > enemySpawner.GetTotalWavesCount())
        {
            EndGame("Congratulations!\n You Won!");
        }
    }

    void EndGame(string endText)
    {
        gameOverText.text = endText;
        uIController.EnableGameOver();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        EnemyDamage enemy = other.gameObject.GetComponent<EnemyDamage>();

        if (enemy != null && other.tag == "Enemy")
        {
            TakeLevelDamage(enemy.GetTouchDamage());
        }
    }

    void TakeLevelDamage(int damage)
    {
        levelHealth -= damage;
        lifeText.text = "Life: " + levelHealth.ToString();
    }

    public void IncreaseTotalMoney(int moneyToAdd)
    {
        money += moneyToAdd;
    }

    public int GetTotalMoney()
    {
        return money;
    }

    public void DecreaseTotalMoney(int moneyToSubtract)
    {
        money -= moneyToSubtract;
    }
}
