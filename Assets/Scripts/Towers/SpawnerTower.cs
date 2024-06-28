using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTower : MonoBehaviour
{
    [SerializeField] int maxMinions = 3;

    [SerializeField] float spawnDelay = 10;
    [SerializeField] float spawnMaxRadius = 0.4f;

    [SerializeField] TowerMinion minionPrefab;
    private Transform targ;

    public Transform Targ => targ;
    private int currentMinionCount;
    private float lastSpawn = 0;

    public void SubMinion()
    {
        currentMinionCount--;
    }
    private void Update() 
    {
        if(currentMinionCount >= maxMinions) return;
        if(Time.time < lastSpawn + spawnDelay) return;
        Instantiate(minionPrefab, transform.position + (Vector3)Random.insideUnitCircle * spawnMaxRadius, Quaternion.identity, this.transform).SetTower(this);
        currentMinionCount++;
        lastSpawn = Time.time;
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        if(targ!=null) return;
        targ = other.transform;
    }
}
