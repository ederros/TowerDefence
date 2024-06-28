using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D myRB;
    [SerializeField] GameObject owner;
    
    protected float damage = 0;
    private float dieTime;
    public void Init(Vector2 velocity, float damage, GameObject owner, float lifetime)
    {
        dieTime = Time.time + lifetime;
        transform.up = velocity;
        this.damage = damage; 
        myRB.velocity = velocity;
        this.owner = owner;
        
    }

    protected virtual void OnTriggerEnter2D(Collider2D other) 
    {
        EntityHealth hp;
        if(other.attachedRigidbody == null) return;
        if(other.attachedRigidbody.TryGetComponent(out hp))
        {
            hp.ReceiveDamage(damage);
            Destroy(this.gameObject);
        }
    }

    private void Update() 
    {
        if(Time.time > dieTime)
        {
            Destroy(this.gameObject);
        }
    }
}
