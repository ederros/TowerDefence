using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowersPool : MonoBehaviour
{
    [SerializeField] private List<BuyableSelectorScriptable> towers;

    public IReadOnlyList<BuyableSelectorScriptable> Towers => towers;

    public void AddToPool(BuyableSelectorScriptable tower)
    {
        if(!towers.Contains(tower))
            towers.Add(tower);
    }

    public void RemoveFromPool(BuyableSelectorScriptable tower) => towers.Remove(tower);

    public BuyableSelectorScriptable[] GetRandomTowers(int count)
    {
        BuyableSelectorScriptable[] buyables = new BuyableSelectorScriptable[count];
        for (int i = 0; i < count; i++)
        {
            buyables[i] = null;
        }
        int index = 0;
        for(int i = 0; i < towers.Count; i++)
        {
            if(Random.Range(0, towers.Count - i) < (count - index))
            {
                buyables[index] = towers[i];
                index++;
            }
                
        }

        return buyables;
    }
}
