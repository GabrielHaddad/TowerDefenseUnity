using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] int levelHealth = 100;
    [SerializeField] TextMeshProUGUI lifeText;
    [SerializeField] TextMeshProUGUI waveText;
    EnemySpawner enemySpawner;

    void Awake() 
    {   
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    void Start() 
    {
        lifeText.text = "Life: " + levelHealth.ToString();
        waveText.text = "Wave: " + enemySpawner.GetCurrentWaveCount() +
                                     "/" + enemySpawner.GetTotalWavesCount();
    }

    void Update() 
    {
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
}
