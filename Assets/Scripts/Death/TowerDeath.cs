using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDeath : Death
{
    private void OnDestroy() {
        GridTowerField.gridTowerField.RemoveTower(transform.position);
    }
}
