using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFinder : MonoBehaviour
{
    private List<Enemy> enemies = new List<Enemy>();
    public IReadOnlyList<Enemy> Enemies => enemies;

    public void CheckAndClean()
    {
        enemies.RemoveAll((e)=>e == null);
    }

    private void EnemyRemove(GameObject go)
    {
        if(go.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemies.Remove(enemy);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Enemy e;
        if(other.attachedRigidbody == null) return;
        if(other.attachedRigidbody.TryGetComponent(out e))
        {
            enemies.Add(e);
            e.DeathHandler.DieEvent += EnemyRemove;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        Enemy e;
        if(other.attachedRigidbody == null) return;
        if(other.attachedRigidbody.TryGetComponent(out e))
        {
            e.DeathHandler.DieEvent -= EnemyRemove;
            enemies.Remove(e);
        }
    }
}
