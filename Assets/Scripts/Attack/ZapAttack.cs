using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ZapAttack : Attack
{
    [SerializeField] private float _damageMultiplierPerZap = 0.8f;
    [SerializeField] private int _zapCount;
    [SerializeField] private EnemyFinder _finder;
    [SerializeField] private LayerMask _enemyLayers;
    [SerializeField] private float _zapRadius;


    /// <summary>
    /// Event describes from - to vectors
    /// </summary>
    public event System.Action<Vector3[]> Zapped;
    public override bool Check() => _finder.Enemies.Count > 0;    
    public override void Punch()
    {
        if(_finder.Enemies[0] == null) return;
        List<Vector3> positions = new List<Vector3>
        {
            transform.position,
            _finder.Enemies[0].transform.position
        };
        _finder.Enemies[0].Health.ReceiveDamage(Damage);
        float curDamage = Damage;
        int i = 1;
        for (; i < _zapCount; i++)
        {
            curDamage *= _damageMultiplierPerZap;
            Collider2D[] colliders = Physics2D.OverlapCircleAll(positions[i], _zapRadius);
            bool isStopped = true;
            foreach (var item in colliders)
            {   
                if(positions.Contains(item.transform.position)) continue;
                if(item == null || item.attachedRigidbody == null) continue;
                if(!item.attachedRigidbody.TryGetComponent(out Enemy enemy)) continue;
                positions.Add(enemy.transform.position);
                enemy.Health.ReceiveDamage(curDamage);
                isStopped = false;
                break;
            }
            if(isStopped) break;
        }
        Zapped.Invoke(positions.ToArray());
    }
}
