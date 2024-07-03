using UnityEngine;

public abstract class AttackEnemy : Attack
{
    public event System.Action<Enemy> EnemyAttacked;
    
    protected void OnEnemyAttacked(Enemy enemy, float damage)
    {
        EnemyAttacked?.Invoke(enemy);
        enemy.Health.ReceiveDamage(damage);
    }
}
