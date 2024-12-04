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
    
    void SetRandEnemyToSpawner()
    {
        Enemy enemy;
        if(currentWave.TryPopRandomEnemy(out enemy))
        {
            var e = spawner.Spawn(enemy);
            //Debug.Log(e);
            e.SetTarget(target);
            lastSpawnedEnemyTime = Time.time;
            nextEnemySpawnTime = Random.Range(currentWave.minMaxSpawnTimeRange.x, currentWave.minMaxSpawnTimeRange.y);
        }
    }

    void CreateNewWave()
    {
        currentWave = creator.CreateWave((int)difficulty);
        difficulty *= difficultySpeed;
        CurrentWaveChanged?.Invoke(difficulty);
    }

    void Update()
    {
        if(currentWave != null && lastSpawnedEnemyTime + nextEnemySpawnTime < Time.time)
            SetRandEnemyToSpawner();

        if(currentWave == null || lastSpawnedEnemyTime + currentWave.timeToWave < Time.time)
            CreateNewWave();
    }
}
