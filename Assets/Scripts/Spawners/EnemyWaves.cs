using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
    public float timeToWave;

    [SerializeField] public List<EnemyGroup> groups = new List<EnemyGroup>();
    [SerializeField] public Vector2 minMaxSpawnTimeRange;
    
    public bool TryPopRandomEnemy(out Enemy enemy)
    {
        int totalCount = 0;
        enemy = null;
        foreach (var item in groups)
        {
            totalCount += item.count;
        }
        if(totalCount <= 0) return false;
        int rand = Random.Range(0, totalCount);
        Enemy target = null;
        foreach (var item in groups)
        {
            rand -= item.count;
            if(rand < 0)
            {
                target = item.enemy;
                item.SubCount(1);
                break;
            }
        }
        enemy = target;

        return true;
    }
}

[System.Serializable]
public class EnemyGroup
{
    public int count;
    public Enemy enemy;
    public void SubCount(int count)
    {
        this.count = Mathf.Max(0, this.count - count);
    }
}

public class EnemyWaves : MonoBehaviour
{
    [SerializeField] EnemySpawner spawner;
    [SerializeField] List<Wave> waves;
    
    [SerializeField] Transform target;
    
    public event System.Action<int> CurrentWaveChanged;

    private float lastSpawnedWaveTime = 0;
    private float lastSpawnedEnemyTime = 0;
    private float nextEnemySpawnTime = 0;
    private int currentWaveIndex = 0;
    private Wave currentWave = null;


    private void Start() {
        lastSpawnedWaveTime = Time.time;
    }

    void Update()
    {   
        if(currentWave != null && lastSpawnedEnemyTime + nextEnemySpawnTime < Time.time)
        {
            Enemy enemy;
            if(currentWave.TryPopRandomEnemy(out enemy))
            {
                spawner.Spawn(enemy).SetTarget(target);
                lastSpawnedEnemyTime = Time.time;
                nextEnemySpawnTime = Random.Range(currentWave.minMaxSpawnTimeRange.x, currentWave.minMaxSpawnTimeRange.y);
            }
        }
        if(currentWaveIndex >= waves.Count) return;
        if(lastSpawnedEnemyTime + waves[currentWaveIndex].timeToWave < Time.time)
        {
            currentWave = waves[currentWaveIndex];
            currentWaveIndex++;
            lastSpawnedWaveTime = Time.time;   
            CurrentWaveChanged?.Invoke(currentWaveIndex);
        }
    }
}
