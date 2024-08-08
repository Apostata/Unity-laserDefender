using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 50;
    [SerializeField] int scoreValue = 10;

    [SerializeField] ParticleSystem exposion;
    [SerializeField] bool sholdShakeCamera = false;
    [SerializeField] bool isPlayer = false;

    UIDisplay uiDisplay;

    ScoreKepper scoreKepper;
    
    CameraShake cameraShake;
    AudioPlayer audioPlayer;

    public float HealthValue { get => health; }

    void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
        if(sholdShakeCamera && isPlayer){
            cameraShake = Camera.main.GetComponent<CameraShake>();
        }
        scoreKepper = FindObjectOfType<ScoreKepper>();
        uiDisplay = FindObjectOfType<UIDisplay>();
        if(isPlayer){
            uiDisplay.InitializeSlider(health, 0);
        }
    }

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

        if(isPlayer){
            uiDisplay.UpdateHealth(health);
        }
        playShakeCamera();

        if (audioPlayer != null)
        {
            audioPlayer.PlayExplosionClip();
        }
        
        if (health <= 0)
        {
            if(!isPlayer){
                scoreKepper.Score += scoreValue; //getter function in scoreKepper increments the score by scoreValue
            } else if(isPlayer){ 
                scoreKepper.Score = 0; //getter function in scoreKepper sets the score to 0
            }
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

    void playShakeCamera()
    {
        if (cameraShake && sholdShakeCamera)
        {
            cameraShake.ShakeCamera();
        }
    }
}
