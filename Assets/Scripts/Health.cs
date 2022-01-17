using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;
    [SerializeField] int moneyValue = 50;
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] ParticleSystem destroyEffect;
    CameraShake cameraShake;
    AudioPlayer audioPlayer;
    GameManager gameManager;

    void Awake() 
    {
        cameraShake = FindObjectOfType<CameraShake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        gameManager = FindObjectOfType<GameManager>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        PlayParticleEffect(destroyEffect);
        audioPlayer.PlayDestroyClip();
        gameManager.IncreaseTotalMoney(moneyValue);
        Destroy(gameObject);
    }

    public int GetHealth()
    {
        return health;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if (damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            PlayParticleEffect(hitEffect);
            ShakeCamera();
            damageDealer.Hit();
        }
    }

    void ShakeCamera()
    {
        if (cameraShake != null)
        {
            cameraShake.Play();
        }
    }

    void PlayParticleEffect(ParticleSystem particle)
    {
        if (hitEffect != null)
        {
            ParticleSystem instance = Instantiate(particle, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }
}
