using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomBoolet : Bullet
{
    [SerializeField] GameObject boomPrefab;
    [SerializeField] float radius;
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(this.gameObject);
    }

    private void OnDestroy() 
    {
        if(boomPrefab != null)
        {
            Instantiate(boomPrefab, transform.position, Quaternion.identity).transform.localScale *= radius * 2;
        }
        
        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, radius, GetComponent<Collider2D>().contactCaptureLayers);
        foreach (Collider2D col in cols)
        {
            if(col.attachedRigidbody.TryGetComponent(out EntityHealth health))
            {
                health.ReceiveDamage(damage * (radius - Vector2.Distance(col.transform.position, transform.position)) / radius);
            }
        }
    }
}
