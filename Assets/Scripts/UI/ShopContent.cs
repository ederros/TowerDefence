using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopContent : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private ShopBuySelector _selectorPrefab;
    [SerializeField] private PlayerScoreView _scoreView;
    
    public void Init(ShopItemsManager items, PlayerScore playerScore)
    {
        _scoreView.Init(playerScore);
        foreach (var item in items.Avaible)
        {
            Instantiate(_selectorPrefab, _container)
                .SetPrice(item.Cost)
                .SetSelector(item.TowerSelector)
                .SetMoney(playerScore.Score)
                .BuyEvent += () => items.AddToBought(item);
        }
        PauseManager.Pause();
    }
}
