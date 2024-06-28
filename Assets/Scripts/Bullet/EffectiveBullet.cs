using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectiveBullet : Bullet
{
    [SerializeField] Enemy.EnemyTags effectiveTags;
    [SerializeField] float multiplier = 2;

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        EntityHealth hp;
        if(other.attachedRigidbody == null) return;
        if(other.attachedRigidbody.TryGetComponent(out hp))
        {
            float dmg = damage;
            if(other.attachedRigidbody.TryGetComponent(out Enemy enemy)){
                if((enemy.Tags & effectiveTags) > 0) dmg *= multiplier;
            }
            hp.ReceiveDamage(dmg);
            Destroy(this.gameObject);
        }
    }
}
