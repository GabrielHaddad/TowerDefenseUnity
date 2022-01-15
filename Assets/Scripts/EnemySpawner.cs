using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] float timeBetweenWaves = 0f;
    [SerializeField] bool isLooping = false;
    WaveConfigSO currentWave;
    
    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }

    public void EnableWaves()
    {
        isLooping = true;
        StartCoroutine(SpawnEnemyWaves());
    }

    public void DisableWaves()
    {
        isLooping = false;
    }

    IEnumerator SpawnEnemyWaves()
    {
        while (isLooping)
        {
            foreach (WaveConfigSO wave in waveConfigs)
            {
                currentWave = wave;

                for (int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(currentWave.GetEnemyPrefab(i), currentWave.GetStartingWaypoint().position,
                    Quaternion.Euler(0 , 0, 90), transform);

                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }

                yield return new WaitForSeconds(timeBetweenWaves);
            }
        }

        yield return null; 
    }

}
