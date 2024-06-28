using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] EnemyMovement _movement;
    [SerializeField] EntityHealth _health;
    [SerializeField] Death _death;

    [System.Flags]
    public enum EnemyTags
    {
        None = 0,
        Boss = 1
    }
    [SerializeField] private EnemyTags tags;
    
    public EnemyTags Tags => tags;
    public Death DeathHandler => _death;
    public EnemyMovement Movement => _movement;
    public EntityHealth Health => _health;

    public void SetTarget(Transform target)
    {
        _movement.SetTarget(target);
    }
}

