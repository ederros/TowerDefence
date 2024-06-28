using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LandMineDeath : TowerDeath
{
    [SerializeField] float boomRadius = 1;
    [SerializeField] float boomDamage = 5;
    [SerializeField] GameObject boomPrefab;
    protected override void Die(GameObject targ)
    {
        base.Die(targ);
        if(boomPrefab != null)
        {
            Instantiate(boomPrefab, transform.position, Quaternion.identity).transform.localScale *= boomRadius * 2;
        }
        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, boomRadius, GetComponent<Collider2D>().contactCaptureLayers);
        foreach (Collider2D col in cols)
        {
            if(col.attachedRigidbody.TryGetComponent(out EntityHealth health))
            {
                health.ReceiveDamage(boomDamage * (boomRadius - Vector2.Distance(col.transform.position, transform.position)) / boomRadius);
            }
        }
    }
}
