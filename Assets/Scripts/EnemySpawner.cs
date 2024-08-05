using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waves;
    [SerializeField] float timeBettweenWaves = 0f;
    [SerializeField] bool isLooping = false;
    WaveConfigSO currentWave;
    public WaveConfigSO CurrentWave { get => currentWave; }
    void Start()
    {
        StartCoroutine(StartWaves());
    }

    IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < currentWave.NumberOfEnemies; i++)
        {
        Instantiate(
            currentWave.GetEnemy(i), 
            currentWave.GetStartingWaypoint.position,
            Quaternion.identity, // No rotation
            transform // Parent the enemy to the spawner
            );
            yield return new WaitForSeconds(currentWave.GetSpanwTime());
        }
       
        
    }

    IEnumerator StartWaves()
    {
        do{
            foreach (WaveConfigSO wave in waves)
            {
                currentWave = wave;
                yield return StartCoroutine(SpawnEnemies());
                yield return new WaitForSeconds(timeBettweenWaves);
            }
        } 
        while (isLooping);
    }
}
