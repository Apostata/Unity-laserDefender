using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
   [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0f, 1f)] float shootingVolume = 1f;

    [Header("Explosion")]
    [SerializeField] AudioClip explosionClip;
    [SerializeField] [Range(0f, 1f)] float explosionVolume = 1f;


    public void PlayShootingClip(){
        PlayClip(shootingClip, shootingVolume);
    }

    public void PlayExplosionClip(){
        PlayClip(explosionClip, explosionVolume);
    }
    
    public void PlayClip(AudioClip clip, float volume){
        if(clip != null){
            AudioSource.PlayClipAtPoint(
                clip, 
                Camera.main.transform.position, 
                volume
            );
        }
    }
}
