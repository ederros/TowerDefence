using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NewTowerManager : MonoBehaviour
{
    [SerializeField] List<NewTowerSelector> selectors;

    public void Init(Transform content, TowersPool pool) 
    {
        PauseManager.Pause();
        BuyableSelectorScriptable[] towers = pool.GetRandomTowers(selectors.Count);
        for(int i = 0; i < towers.Length; i++)
        {
            BuyableSelectorScriptable tower = towers[i];
            selectors[i].Init(tower, content, () => {
                pool.RemoveFromPool(tower);
            });
        }
    }
}
