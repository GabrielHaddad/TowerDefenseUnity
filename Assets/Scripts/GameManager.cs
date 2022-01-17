using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] int levelHealth = 100;
    [SerializeField] TextMeshProUGUI lifeText;
    [SerializeField] TextMeshProUGUI waveText;
    [SerializeField] TextMeshProUGUI moneyText;
    EnemySpawner enemySpawner;
    int money = 0;

    void Awake() 
    {   
        enemySpawner = FindObjectOfType<EnemySpawner>();
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
