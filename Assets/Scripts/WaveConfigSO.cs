using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] Transform path;
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] List<GameObject> enemies;
    [SerializeField] float timeBettweenSpawns = 1f;
    [SerializeField] float spanwTimeVariance = 0f;
    [SerializeField] float minimimSpawnTime = 0.2f;

    public Transform Path { get => path; }
    public float MoveSpeed { get => moveSpeed; }

    public int NumberOfEnemies { get => enemies.Count; }

    public float  GetSpanwTime(){
        float spanwTime = Random.Range(timeBettweenSpawns - spanwTimeVariance, timeBettweenSpawns + spanwTimeVariance);
        return Mathf.Clamp(spanwTime, minimimSpawnTime, float.MaxValue);
    }

    public GameObject GetEnemy(int index)
    {
        return enemies[index];
    }

    public Transform GetStartingWaypoint { get => path.GetChild(0); }

    public List<Transform> GetWaypoints()
    {
        List<Transform> waypoints = new();

        foreach (Transform waypoint in path)
        {
            waypoints.Add(waypoint);
        }

        return waypoints;
    }

}
