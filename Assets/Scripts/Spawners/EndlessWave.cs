using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessWave : MonoBehaviour
{
    [SerializeField] private EnemySpawner spawner;
    [SerializeField] private Transform target;
    [SerializeField] private WaveCreator creator;
    [SerializeField] private float difficulty = 10;
    [SerializeField] private float difficultySpeed = 1.2f;
    public event System.Action<float> CurrentWaveChanged;
    private Wave currentWave = null;
    private float lastSpawnedEnemyTime;
    private float nextEnemySpawnTime;
    
    void Update()
    {
        if(currentWave != null && lastSpawnedEnemyTime + nextEnemySpawnTime < Time.time)
        {
            Enemy enemy;
            if(currentWave.TryPopRandomEnemy(out enemy))
            {
                Debug.Log(target);
                spawner.Spawn(enemy).SetTarget(target);
                lastSpawnedEnemyTime = Time.time;
                nextEnemySpawnTime = Random.Range(currentWave.minMaxSpawnTimeRange.x, currentWave.minMaxSpawnTimeRange.y);
            }
        }

        if(currentWave == null || lastSpawnedEnemyTime + currentWave.timeToWave < Time.time)
        {
            currentWave = creator.CreateWave((int)difficulty);
            difficulty *= difficultySpeed;
            CurrentWaveChanged?.Invoke(difficulty);
        }
    }
}
