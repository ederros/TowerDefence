using System.Collections.Generic;
using UnityEngine;

public class ContactAttackTrigger : Attack
{
    List<EntityHealth> entityHealths = new List<EntityHealth>();
    [SerializeField] LayerMask target;
    public override void Punch()
    {
        entityHealths.RemoveAll((e) => e == null);
        for (int i = 0; i < entityHealths.Count; i++)
        {
            entityHealths[i].ReceiveDamage(Damage);
        }
    }

    public override bool Check()
    {
        return entityHealths.Count > 0;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(((1<<other.attachedRigidbody.gameObject.layer) & target.value) == 0 || !other.attachedRigidbody.transform.TryGetComponent(out EntityHealth health)) return;
        entityHealths.Add(health);
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(!other.attachedRigidbody.transform.TryGetComponent(out EntityHealth health) || ((1<<other.attachedRigidbody.gameObject.layer) & target.value) == 0) return;
        entityHealths.Remove(health);
    }
}
