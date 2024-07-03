using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveCreator : MonoBehaviour
{
    [System.Serializable]
    struct EnemyCost
    {
        public Enemy enemy;
        public int cost;
        public float minDifficult;
        public float maxDifficult;
    }
    [SerializeField] private List<EnemyCost> enemyPool;
    [SerializeField] private float timeToWaveModifier = 10;
    [SerializeField] private int enemyPowerModifier = 1;
    
    private const int MAX_ITERATONS = 10;
    private const int MAX_RANDOM_GROUP = 3;
    public Wave CreateWave(int difficulty)
    {
        Wave wave = new Wave();
        wave.minMaxSpawnTimeRange = new Vector2(10,11)/difficulty;
        wave.timeToWave = timeToWaveModifier + Mathf.Sqrt(difficulty)/2;

        
        int credits = difficulty * enemyPowerModifier;
        int debuge = 0;
        while(credits > 0)
        {
            EnemyGroup group = new EnemyGroup();
            int cost = 0;
            while(group.count == 0)
            {
                
                int enemy = Random.Range(0, enemyPool.Count);
                while(enemyPool[enemy].minDifficult > difficulty || (enemyPool[enemy].maxDifficult < difficulty && enemyPool[enemy].maxDifficult != 0))
                    enemy = Random.Range(0, enemyPool.Count);
                debuge++;
                
                group.count = credits/enemyPool[enemy].cost;
                if(group.count > 0)
                {
                    for(int i = 0; i < MAX_RANDOM_GROUP; i++)
                        group.count = Random.Range(1, group.count+1);
                }
                
                cost = enemyPool[enemy].cost * group.count;
                
                group.enemy = enemyPool[enemy].enemy;
               
                if(debuge > MAX_ITERATONS) break;
            }
            credits -= cost;
            if(debuge > MAX_ITERATONS) break;
            wave.groups.Add(group);
        }        
        
        return wave;
    }
}
