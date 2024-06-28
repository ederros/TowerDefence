using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMinion : MonoBehaviour
{
    private SpawnerTower tower;
    [SerializeField] private float minDistToTower = 1;
    [SerializeField] Rigidbody2D myRB;
    [SerializeField] float speed = 1;
    void Update()
    {
        if(tower.Targ == null)
        {
            if(Vector2.Distance(transform.parent.position, transform.position) > minDistToTower) myRB.velocity = (transform.parent.position - transform.position).normalized * speed;
        }
        else
        {
            myRB.velocity = (tower.Targ.position - transform.position).normalized * speed;
        }
    }
    
    public void SetTower(SpawnerTower tower)
    {
        this.tower = tower;
    }

    private void OnDestroy() 
    {
        tower.SubMinion();
    }
}
