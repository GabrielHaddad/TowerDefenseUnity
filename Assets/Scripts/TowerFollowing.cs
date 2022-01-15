using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerFollowing : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Transform gunPoint;
    [SerializeField] float findEnemiesRadius = 5f;
    [SerializeField] LayerMask enemyFilter;
    Collider2D[] enemies;
    Transform currentEnemyTarget;


    // Start is called before the first frame update
    void Start()
    {

    }

    void LookForEnemies()
    {
        enemies = Physics2D.OverlapCircleAll(transform.position, findEnemiesRadius, enemyFilter);

        if (!IsColliderArrayEmpty(enemies))
        {
            ChangeCurrentTarget();
        }
        else
        {
            currentEnemyTarget = null;
        }
    }

    void ChangeCurrentTarget()
    {
        Collider2D found = Array.Find(enemies, element => element.gameObject.transform == currentEnemyTarget);

        if (found != null)
        {
            currentEnemyTarget = found.transform;
        }
        else
        {
            currentEnemyTarget = enemies.First().transform;
        }
    }

    bool IsColliderArrayEmpty(Collider2D[] array)
    {
        if (array == null)
        {
            return true;
        }

        return array.Length == 0;
    }

    void FixedUpdate()
    {
        LookForEnemies();

        if (currentEnemyTarget != null)
        {
            FollowEnemy();
        }
    }

    void FollowEnemy()
    {
        Vector3 difference = currentEnemyTarget.position - gunPoint.position;
        difference.Normalize();
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg - 90f;
        gunPoint.rotation = Quaternion.Euler(0f, 0f, rotationZ);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // if (!EventSystem.current.IsPointerOverGameObject())
        // {
        //     Debug.Log("UIIIIIIIIII");
        // }

        // Debug.Log("clicked pointer");
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, findEnemiesRadius);
    }
}
