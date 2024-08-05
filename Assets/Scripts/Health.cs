using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 50;

    [SerializeField] ParticleSystem exposion;
    public float HealthPoints { get => health; }

    void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        if (damageDealer != null)
        {
            TakeDamage(damageDealer.Damage); // Take damage
            playExplosion(); // Play explosion
            damageDealer.Hit(); // Destroy the damage dealer
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void playExplosion()
    {
        if (exposion != null)
        {
            ParticleSystem explosionInstance = Instantiate(exposion, transform.position, Quaternion.identity);
            Destroy(explosionInstance.gameObject, explosionInstance.main.duration + explosionInstance.main.startLifetime.constantMax);
        }
    }
}
