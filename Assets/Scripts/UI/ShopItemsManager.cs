using System;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemsManager : MonoBehaviour, ISaveLoadable
{
    [SerializeField] private List<string> _bought = new List<string>();
    [SerializeField] private TowersPool _towers;

    [Serializable]
    private class DataToSave
    {
        public List<string> bought;
    }
    private List<ShopBuyableScriptable> _avaible = new List<ShopBuyableScriptable>();

    public IReadOnlyList<ShopBuyableScriptable> Avaible => _avaible;

    private void Awake() 
    {
        _avaible = LoadAvaible();
    }

    public void AddToBought(ShopBuyableScriptable item)
    {
        _bought.Add(item.name);
        _avaible.RemoveAll(g => g.TowerSelector == item.TowerSelector);
    }

    private List<ShopBuyableScriptable> LoadAvaible()
    {
        List<ShopBuyableScriptable> avaible = new List<ShopBuyableScriptable>(); 
        foreach (var item in Resources.LoadAll<ShopBuyableScriptable>(""))
        {
            if(_bought.Contains(item.name)) 
            {
                _towers.AddToPool(item.TowerSelector);
                continue;
            }
            avaible.Add(item);
        }
        return avaible;
    }

    public Type GetSavedDataType() => typeof(DataToSave);

    public void Load(object data)
    {
        _bought = ((DataToSave)data).bought;   
    }

    public void Save(out object data)
    {
        data = new DataToSave()
        {
            bought = _bought
        };
    }
}
