using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    [SerializeField] int touchDamage = 1;

    public int GetTouchDamage()
    {
        return touchDamage;
    }
}
