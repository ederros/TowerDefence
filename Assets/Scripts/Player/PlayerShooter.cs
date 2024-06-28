using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : BulletShooter
{
    [SerializeField] private EnemyFinder finder;

    public override bool Check() => finder.Enemies.Count > 0;
    public override void Punch()
    {
        if(finder.Enemies[0] == null)
        {
            finder.CheckAndClean();
            return;
        }
        SpawnBullet(finder.Enemies[0].transform.position - transform.position);
    }
}
