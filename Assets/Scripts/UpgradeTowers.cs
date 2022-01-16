using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeTowers : MonoBehaviour
{
    
    public void UpgradeSpeed(GameObject tower)
    {
        UpgradeConfigs upgradeConfig = tower.GetComponent<UpgradeConfigs>();

        upgradeConfig.IncreaseCurrentSpeedUpgrade();
        tower.GetComponent<Shooter>().IncreaseProjectileSpeed(upgradeConfig.GetSpeedToIncrease());

    }

    public void UpgradeRange(GameObject tower)
    {
        UpgradeConfigs upgradeConfig = tower.GetComponent<UpgradeConfigs>();

        upgradeConfig.IncreaseCurrentRangeUpgrade();
        tower.GetComponent<TowerFollowing>().IncreaseTowerRange(upgradeConfig.GetRangeToIncrease());
    }

    public void UpgradeDamage(GameObject tower)
    {
        UpgradeConfigs upgradeConfig = tower.GetComponent<UpgradeConfigs>();

        upgradeConfig.IncreaseCurrentDamageUpgrade();
        tower.GetComponent<Shooter>().IncreaseUpgradedBulletDamage(upgradeConfig.GetDamageToIncrease());
    }


}
