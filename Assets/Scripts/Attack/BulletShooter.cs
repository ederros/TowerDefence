using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletShooter : Attack
{
    [SerializeField] protected Bullet bulletPrefab;
    [SerializeField] protected CircleCollider2D radius;
    [SerializeField] protected float bulletSpeed = 1;
    
    protected void SpawnBullet(Vector2 dir)
    {

        Instantiate(bulletPrefab, transform.position, Quaternion.identity).Init(dir.normalized * bulletSpeed, Damage, this.gameObject, radius.radius / bulletSpeed);
    }

   

    

   
}
