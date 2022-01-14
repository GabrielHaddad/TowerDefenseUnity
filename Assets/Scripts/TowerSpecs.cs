using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpecs : MonoBehaviour
{
    TowerSpawner towerSpawner;

    void Awake() 
    {
        towerSpawner = FindObjectOfType<TowerSpawner>();
    }

    void Start()
    {
        
    }

    public void OpenTowerSpecs()
    {
        towerSpawner.DisableTowerPlacing();
    }
}
