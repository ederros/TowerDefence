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
    }
    [SerializeField] List<EnemyCost> enemyPool;
    [SerializeField] float timeToWaveModifier = 10;
    [SerializeField] int enemyPowerModifier = 1;
    
    
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
                while(enemyPool[enemy].minDifficult > difficulty)
                    enemy = Random.Range(0, enemyPool.Count);
                debuge++;
                
                group.count = credits/enemyPool[enemy].cost;
                if(group.count>0)
                {
                    group.count = Random.Range(1, group.count+1);
                    group.count = Random.Range(1, group.count+1);
                    group.count = Random.Range(1, group.count+1);
                }
                
                cost = enemyPool[enemy].cost * group.count;
                
                group.enemy = enemyPool[enemy].enemy;
               
                if(debuge > 100) break;
            }
            credits -= cost;
            if(debuge > 100) break;
            wave.groups.Add(group);
        }
        if(debuge > 100) return null;
        
        
        return wave;
    }
}
