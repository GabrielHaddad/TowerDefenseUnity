using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 5f;
    [SerializeField] float baseFiringRate = 0.2f;
    int bulletUpgradedDamage;
    Transform gunPoint;
    bool isFiring = false;
    Coroutine firingCoroutine;
    AudioPlayer audioPlayer;

    void Awake() 
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void Start()
    {
        bulletUpgradedDamage = projectilePrefab.GetComponent<DamageDealer>().GetDamage();
        gunPoint = transform.GetChild(0).transform;
    }

    void Update()
    {
        Fire();
    }

    public void StartFiring()
    {
        isFiring = true;
    }

    public void StopFiring()
    {
        isFiring = false;
    }

    public void IncreaseProjectileSpeed(float speedToAdd)
    {
        projectileSpeed += speedToAdd;
    }

    void Fire()
    {
        if (isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        else if (!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    public void IncreaseUpgradedBulletDamage(int damage)
    {
        bulletUpgradedDamage += damage;
    }

    void IncreaseInstanceBulletDamage(GameObject bullet)
    {
        bullet.GetComponent<DamageDealer>().SetDamage(bulletUpgradedDamage);
    }

    IEnumerator FireContinuously()
    {
        while (true) 
        {
            GameObject instance = Instantiate(projectilePrefab, 
                                    gunPoint.position, gunPoint.rotation);
            
            IncreaseInstanceBulletDamage(instance);
            
            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.velocity = gunPoint.up * projectileSpeed;
            }

            Destroy(instance, projectileLifetime);

            audioPlayer.PlayShootingClip();
            
            yield return new WaitForSeconds(baseFiringRate);
        }
    }
}
