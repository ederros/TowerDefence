using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbberationDeath : EnemyDeath
{
    [SerializeField] private Enemy enemyToSpawn = null;
    [SerializeField] EnemyMovement myMovement;
    [SerializeField] private int count = 3;
    [SerializeField] private float radius = 1;
    protected override void Die(GameObject targ)
    {
        for (int i = 0; i < count; i++)
        {
            Instantiate(enemyToSpawn, transform.position + (Vector3)Random.insideUnitCircle * radius, Quaternion.identity, transform.parent).SetTarget(myMovement.GetTarget());
        }
        base.Die(targ);   
    }
}
