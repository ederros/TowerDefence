using UnityEngine;

public class AttackAllEnemies : AttackEnemy
{
    [SerializeField] private EnemyFinder _finder;
    
    public override bool Check()
    {
        return _finder.Enemies.Count > 0;
    }
    public override void Punch()
    {
        for (int i = 0; i < _finder.Enemies.Count; i++)
        {
            OnEnemyAttacked(_finder.Enemies[i], Damage);
        }
    }
}
