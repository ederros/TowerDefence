using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    [SerializeField] Enemy enemy;

    Transform originTarget = null;

    private void Start() 
    {
        originTarget = enemy.Movement.GetTarget();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(enemy.Movement.GetTarget() != originTarget) return;
        if(!other.TryGetComponent(out EntityHealth health)) return;
        health.ValueChanged += (float val) =>
        {
            if(val <= 0)
            {
                enemy.SetTarget(originTarget);
            }
        };
        enemy.SetTarget(other.transform);
    }
}
