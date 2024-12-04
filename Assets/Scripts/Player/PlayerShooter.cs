using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : BulletShooter
{
    [SerializeField] private Finder finder;

    public override bool Check() => finder.Objects.Count > 0;
    public override void Punch()
    {
        if(finder.Objects[0] == null)
        {
            finder.CheckAndClean();
            return;
        }
        SpawnBullet(finder.Objects[0].transform.position - transform.position);
    }
}
