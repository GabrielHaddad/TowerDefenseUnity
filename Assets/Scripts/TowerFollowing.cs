using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerFollowing : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Transform gunPoint;
    [SerializeField] float findEnemiesRadius = 5f;
    Transform enemyPosition;


    // Start is called before the first frame update
    void Start()
    {

    }

    void Update() 
    {
        LookForEnemies();
    }

    void LookForEnemies()
    {
        Collider2D enemy = Physics2D.OverlapCircle(transform.position, findEnemiesRadius);
        
        if (enemy != null && enemy.tag == "Enemy")
        {
            enemyPosition = enemy.gameObject.transform;
        }
        else
        {
            enemyPosition = null;
        }
    }

    void FixedUpdate() 
    {
        if (enemyPosition != null)
        {
            FollowEnemy();
        }
    }

    void FollowEnemy()
    {
        Vector3 difference = enemyPosition.position - gunPoint.position;
        difference.Normalize();
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg - 90f;
        gunPoint.rotation = Quaternion.Euler(0f, 0f, rotationZ);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            Debug.Log("UIIIIIIIIII");
        }

        Debug.Log("clicked pointer");
    }

    void OnDrawGizmosSelected()
    {
        // Gizmos.color = Color.yellow;
        // Gizmos.DrawSphere(transform.position, findEnemiesRadius);
    }
}
