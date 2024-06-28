using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] public float width = 5;
    [SerializeField] public Transform parent;
    public event System.Action<Enemy> spawnEvent;

    public Vector2 GetRandomPoint() => Vector2.right * Random.Range(-width, width);
    public Enemy Spawn(Enemy enemy)
    {
        Enemy spawnedEnemy = Instantiate(enemy, transform.position + (Vector3)GetRandomPoint(), Quaternion.identity, parent);
        spawnEvent?.Invoke(spawnedEnemy);
        return spawnedEnemy;
    }

    #if UNITY_EDITOR
    private void OnDrawGizmos() 
    {
        Gizmos.DrawLine(transform.position + Vector3.right * width, transform.position + Vector3.left * width);
    }
    #endif
}
