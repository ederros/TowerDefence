using UnityEngine;

public class AttackAllEnemies : AttackEnemy
{
    [SerializeField] private Finder _finder;
    
    public override bool Check()
    {
        return _finder.Objects.Count > 0;
    }
    public override void Punch()
    {
        for (int i = 0; i < _finder.Objects.Count; i++)
        {
            if(_finder.Objects[i].TryGetComponent(out Enemy enemy))
                OnEnemyAttacked(enemy, Damage);
        }
    }
}
