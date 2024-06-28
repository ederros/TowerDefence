using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyBtn : MonoBehaviour
{
    public void DestroyTower()
    {
        Vector2 pos = PlayerCircleMovement.PlayerMovement.transform.position;
        if(GridTowerField.gridTowerField.CheckField(pos))
        {
            GameObject tower = GridTowerField.gridTowerField.GetTower(pos);
            GridTowerField.gridTowerField.RemoveTower(pos);
            Destroy(tower);
        }
        
    }
}
