using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealTower : MonoBehaviour
{
    [SerializeField] float healAmount;
    [SerializeField] float timeToHeal;
    private float lastHealTime;
    private TowerContainer[] containers;
    private void Start() 
    {
        lastHealTime = Time.time;
        Init();
    }
    public void Init()
    {
        containers = new TowerContainer[6];
        Vector2Int pos = (Vector2Int)GridTowerField.gridTowerField.GetGrid().WorldToCell(transform.position);
        containers[0] = GridTowerField.gridTowerField.GetTowerContainer(pos + Vector2Int.down);
        containers[1] = GridTowerField.gridTowerField.GetTowerContainer(pos + Vector2Int.up);
        containers[2] = GridTowerField.gridTowerField.GetTowerContainer(pos + Vector2Int.left);
        containers[3] = GridTowerField.gridTowerField.GetTowerContainer(pos + Vector2Int.right);
        if(pos.y % 2 == 0)
        {
            containers[4] = GridTowerField.gridTowerField.GetTowerContainer(pos + new Vector2Int(-1, 1));
            containers[5] = GridTowerField.gridTowerField.GetTowerContainer(pos - Vector2Int.one);
        }
        else
        {
            containers[4] = GridTowerField.gridTowerField.GetTowerContainer(pos + Vector2Int.one);
            containers[5] = GridTowerField.gridTowerField.GetTowerContainer(pos + new Vector2Int(1, -1));
        }

    }
    void Update()
    {
        if(Time.time < lastHealTime + timeToHeal) return;
        lastHealTime = Time.time;
        foreach (var item in containers)
        {
            Debug.Log(item);
            if(item.tower == null) continue;
            EntityHealth hp = item.tower.GetComponentInChildren<EntityHealth>();
            if(hp == null) continue;
            hp.AddValue(healAmount);
        }
    }
    // [SerializeField] float debugRadius = 0.05f;
    // private void OnDrawGizmos() 
    // {
    //     if(GridTowerField.gridTowerField == null) return;
    //     Vector2Int pos = (Vector2Int)GridTowerField.gridTowerField.GetGrid().WorldToCell(transform.position);
    //     Gizmos.DrawSphere(GridTowerField.gridTowerField.GetGrid().CellToWorld((Vector3Int)(pos + Vector2Int.down)), debugRadius);
    //     Gizmos.DrawSphere(GridTowerField.gridTowerField.GetGrid().CellToWorld((Vector3Int)(pos - Vector2Int.down)), debugRadius);
    //     Gizmos.DrawSphere(GridTowerField.gridTowerField.GetGrid().CellToWorld((Vector3Int)(pos + Vector2Int.right)), debugRadius);
    //     Gizmos.DrawSphere(GridTowerField.gridTowerField.GetGrid().CellToWorld((Vector3Int)(pos - Vector2Int.right)), debugRadius);
    //     if(pos.y % 2 == 0)
    //     {
    //         Gizmos.DrawSphere(GridTowerField.gridTowerField.GetGrid().CellToWorld((Vector3Int)(pos + new Vector2Int(-1, 1))), debugRadius);
    //         Gizmos.DrawSphere(GridTowerField.gridTowerField.GetGrid().CellToWorld((Vector3Int)(pos - Vector2Int.one)), debugRadius);
    //     }
    //     else
    //     {
    //         Gizmos.DrawSphere(GridTowerField.gridTowerField.GetGrid().CellToWorld((Vector3Int)(pos + Vector2Int.one)), debugRadius);
    //         Gizmos.DrawSphere(GridTowerField.gridTowerField.GetGrid().CellToWorld((Vector3Int)(pos + new Vector2Int(1, -1))), debugRadius);
    //     }
    // }
}
