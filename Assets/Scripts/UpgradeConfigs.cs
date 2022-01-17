using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeConfigs : MonoBehaviour
{
    [Header("Tower")]
    [SerializeField] int towerValue = 50;

    [Header("Speed")]
    [SerializeField] int maxSpeedUpgrade = 1;
    [SerializeField] float speedToIncrease = 10f;
    [SerializeField] int speedCost = 50;
    int currentSpeedUpgrade = 0;

    [Header("Range")]
    [SerializeField] int maxRangeUpgrade = 1;
    [SerializeField] float rangeToIncrease = 1f;
    [SerializeField] int rangeCost = 50;
    int currentRangeUpgrade = 0;

    [Header("Damage")]
    [SerializeField] int maxDamageUpgrade = 1;
    [SerializeField] int damageToIncrease = 10;
    [SerializeField] int damageCost = 50;
    int currentDamageUpgrade = 0;

    public bool CheckIfCanUpgradeSpeed()
    {
        if (currentSpeedUpgrade >= maxSpeedUpgrade)
        {
            return false;
        }
        
        return true;
    }

    public bool CheckIfCanUpgradeDamage()
    {
        if (currentDamageUpgrade >= maxDamageUpgrade)
        {
            return false;
        }
        
        return true;
    }

    public bool CheckIfCanUpgradeRange()
    {
        if (currentRangeUpgrade >= maxRangeUpgrade)
        {
            return false;
        }
        
        return true;
    }

    public int GetTowerValue()
    {
        return towerValue;
    }

    public void IncreaseCurrentSpeedUpgrade()
    {
        currentSpeedUpgrade++;
    }

    public int GetCurrentSpeedUpgrade()
    {
        return currentSpeedUpgrade;
    }

    public float GetSpeedToIncrease()
    {
        return speedToIncrease;
    }

    public int GetMaxSpeedUpgrade()
    {
        return maxDamageUpgrade;
    }

    public int GetSpeedCost()
    {
        return speedCost;
    }



    public void IncreaseCurrentDamageUpgrade()
    {
        currentDamageUpgrade++;
    }

    public int GetCurrentDamageUpgrade()
    {
        return currentDamageUpgrade;
    }

    public int GetDamageToIncrease()
    {
        return damageToIncrease;
    }

    public int GetMaxDamageUpgrade()
    {
        return maxDamageUpgrade;
    }
    public int GetDamageCost()
    {
        return damageCost;
    }



    public void IncreaseCurrentRangeUpgrade()
    {
        currentRangeUpgrade++;
    }

    public int GetCurrentRangeUpgrade()
    {
        return currentRangeUpgrade;
    }

    public float GetRangeToIncrease()
    {
        return rangeToIncrease;
    }

    public int GetMaxRangeUpgrade()
    {
        return maxRangeUpgrade;
    }

    public int GetRangeCost()
    {
        return rangeCost;
    }
}
