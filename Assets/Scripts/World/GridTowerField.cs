using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridTowerField : MonoBehaviour
{
    [SerializeField] Grid grid;
    [SerializeField] Tilemap tilemap;
    [SerializeField] Tile gridTile;
    private static GridTowerField _gridTowerField;
    public static GridTowerField gridTowerField => _gridTowerField;
    private Dictionary<Vector2Int, TowerContainer> towers = new Dictionary<Vector2Int, TowerContainer>();

    public Grid GetGrid() => grid;

#region Checking
    public bool CheckTile(Vector2 pos) => CheckTile((Vector2Int)grid.WorldToCell(pos));
    public bool CheckTile(Vector2Int pos) => tilemap.GetTile((Vector3Int)pos) == gridTile;

    public bool CheckForTower(Vector2 pos) => CheckForTower((Vector2Int)grid.WorldToCell(pos));

    public bool CheckForTower(Vector2Int pos) => GetTowerContainer(pos).tower != null;
    
    public bool CheckField(Vector2 field) => CheckField((Vector2Int)grid.WorldToCell(field));

    public bool CheckField(Vector2Int field) => towers.ContainsKey(field);
#endregion
    private void Awake() 
    {
        _gridTowerField = this;
    }


    //Get tower container by world position
    public TowerContainer GetTowerContainer(Vector2 position)
    {
        return GetTowerContainer((Vector2Int)grid.WorldToCell(position));
    }

    //Get tower container by grid position
    public TowerContainer GetTowerContainer(Vector2Int position)
    {
        if(!towers.TryGetValue(position, out TowerContainer tower)) {
            tower = new TowerContainer();
            towers.Add(position, tower);
        }
        return tower;
    }

    public void SetTower(Vector2 position, GameObject tower)
    {
        Vector2Int pos = (Vector2Int)grid.WorldToCell(position);
        //if(!CheckField(position)) return false;
        
        GetTowerContainer(pos).tower = tower;
        tower.transform.position = grid.CellToWorld((Vector3Int)pos);
    }
    public GameObject GetTower(Vector2 position)
    {
        Vector2Int pos = (Vector2Int)grid.WorldToCell(position);
        
        return GetTowerContainer(pos).tower;
    }

    public void RemoveTower(Vector2 position)
    {
        if(grid == null) return;
        Vector2Int pos = (Vector2Int)grid.WorldToCell(position);
        //if(!CheckField(position)) return false;
        GetTowerContainer(pos).tower = null;
    }
}

public class TowerContainer
{
    public GameObject tower = null;
}
