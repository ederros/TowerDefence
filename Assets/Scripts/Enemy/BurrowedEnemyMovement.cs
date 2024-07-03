using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurrowedEnemyMovement : EnemyMovement
{
    [SerializeField] Vector2 offset;
    [SerializeField] float timeToUnBurrow = 5;
    [SerializeField] float unburrowedSpeed = 5;
    
    protected override Vector2 GetTargetPosition() => (Vector2)_target.position + offset;

    public event System.Action UnBurrow;
    private float startTime;
    Collider2D[] myColliders;
    SpriteRenderer[] mySprites;
    private static LayerMask enemyLayer = -1;

    private void Start() 
    {
        if(enemyLayer == -1)
            enemyLayer = LayerMask.NameToLayer("Enemy");
        
            
        
        myColliders = GetComponentsInChildren<Collider2D>();
        mySprites = GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer item in mySprites)
        {
            item.color = new Color(item.color.r, item.color.g, item.color.b, item.color.a*0.5f);
        }
        foreach (Collider2D item in myColliders)
        {
            item.enabled = false;
            item.gameObject.layer = enemyLayer;
        }
        startTime = Time.time;
    }
    protected override void Update() 
    {
        base.Update();
        if(Time.time > startTime + timeToUnBurrow)
        {
            _speed = unburrowedSpeed;
            UnBurrow?.Invoke();
            foreach (Collider2D item in myColliders)
            {
                item.enabled = true;
                item.gameObject.layer = enemyLayer;
            }
            foreach (SpriteRenderer item in mySprites)
            {
                item.color = new Color(item.color.r, item.color.g, item.color.b, item.color.a*2);
            }
            offset = Vector2.zero;
        }
    }
}
