using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewTowerManager : MonoBehaviour
{
    [SerializeField] List<BuyableSelectorScriptable> towers;
    [SerializeField] List<NewTowerSelector> selectors;
    public List<BuyableSelectorScriptable> Towers => towers;
    private static NewTowerManager instance;
    public static NewTowerManager Instance => instance;

    public void Init()
    {
        instance = this;
    }
    public void AddToPool(BuyableSelectorScriptable tower)
    {
        if(!towers.Contains(tower))
            towers.Add(tower);
    }
    
    private void OnEnable() 
    {
        Time.timeScale = 0;
        int freeSpace = selectors.Count;
        int freeTowers = towers.Count;
        foreach (NewTowerSelector item in selectors)
        {
            BuyableSelectorScriptable buyable = null;
            for(int i = towers.Count - freeTowers; i < towers.Count; i++)
            {
                int c = Random.Range(0, freeTowers);
                freeTowers--;
                if(c < freeSpace) 
                {
                    buyable = towers[i];
                    break;
                }
                
            }
            item.Init(buyable, () =>
            {
                towers.Remove(buyable);
                Time.timeScale = 1;
                gameObject.SetActive(false);
                foreach (NewTowerSelector it in selectors)
                {
                    foreach(Transform c in it.GetViewTarget())
                    {
                        
                        Destroy(c.gameObject);
                    }
                }
            });
            freeSpace--;
        }
    }
}
