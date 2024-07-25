using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    EnemySpawner enemySpawner;
    WaveConfigSO waveConfig;
    List<Transform> waypoints;
    int currentWaypointIndex = 0;

    void Awake()
    {
      enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    void Start()
    {
        waveConfig = enemySpawner.CurrentWave;
        waypoints = waveConfig.GetWaypoints(); 
        transform.position = waypoints[currentWaypointIndex].position;  
    }

    void Update()
    {
        FollowPath();
    }

    void FollowPath()
    {
        float shipSpeed = gameObject.GetComponent<Enemy>().ShipSpeed;
       if(currentWaypointIndex < waypoints.Count)
       {
         Vector2 targetPosition = waypoints[currentWaypointIndex].position;
         float movementSpeed = shipSpeed * Time.deltaTime;
         transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementSpeed);

         if(transform.position == (Vector3)targetPosition){
            currentWaypointIndex++;
         }
       } else {
         Destroy(gameObject);
       }
    }
}
