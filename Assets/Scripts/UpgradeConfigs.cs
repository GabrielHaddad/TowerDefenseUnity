using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeConfigs : MonoBehaviour
{
    [Header("Speed")]
    [SerializeField] int maxSpeedUpgrade = 1;
    [SerializeField] float speedToIncrease = 10f;
    int currentSpeedUpgrade = 0;

    [Header("Range")]
    [SerializeField] int maxRangeUpgrade = 1;
    [SerializeField] float rangeToIncrease = 1f;
    int currentRangeUpgrade = 0;

    [Header("Damage")]
    [SerializeField] int maxDamageUpgrade = 1;
    [SerializeField] int damageToIncrease = 10;
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
}
