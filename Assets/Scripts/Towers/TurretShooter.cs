using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShooter : BulletShooter
{
    
    [SerializeField] Turret turret;
    [SerializeField] TurretTargeter targeter;

    public override bool Check() => targeter.IsTrackedTarget;

    public override void Punch()
    {
        SpawnBullet(turret.Head.transform.up);
    }
}
