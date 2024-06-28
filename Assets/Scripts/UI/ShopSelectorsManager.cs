using System;
using System.Collections.Generic;
using UnityEngine;

public class ShopSelectorsManager : MonoBehaviour, ISaveLoadable
{
    private List<string> _bought = new List<string>();

    [Serializable]
    private class DataToSave
    {
        public List<string> _bought;
    }
    private List<ShopBuyableScriptable> _avaible = new List<ShopBuyableScriptable>();
    [SerializeField] private ShopBuySelector _selectorPrefab;
    [SerializeField] private Transform _container;
    [SerializeField] private PlayerScore _score;

    public void Init()
    {
        _avaible = LoadAvaible();

        foreach (var item in _avaible)
        {
            Instantiate(_selectorPrefab, _container)
                .SetPrice(item.Cost)
                .SetSelector(item.TowerSelector)
                .SetMoney(_score.Score)
                .BuyEvent += () =>
                {
                    _bought.Add(item.name);
                    _avaible.RemoveAll(g => g.TowerSelector == item.TowerSelector);
                };
        }
        PauseManager.Pause();
    }

    private List<ShopBuyableScriptable> LoadAvaible()
    {
        List<ShopBuyableScriptable> avaible = new List<ShopBuyableScriptable>(); 
        foreach (var item in Resources.LoadAll<ShopBuyableScriptable>(""))
        {
            if(_bought.Contains(item.name)) {
                NewTowerManager.Instance.AddToPool(item.TowerSelector);
                continue;
            }
            avaible.Add(item);
        }
        return avaible;
    }

    public Type GetSavedDataType() => typeof(DataToSave);

    public void Load(object data)
    {
        _bought = ((DataToSave)data)._bought;
        
    }

    public void Save(out object data)
    {
        data = new DataToSave()
        {
            _bought = _bought
        };
    }
}
