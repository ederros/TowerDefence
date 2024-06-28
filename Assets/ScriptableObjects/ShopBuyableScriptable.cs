using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopBuyableScriptable")]
public class ShopBuyableScriptable : ScriptableObject 
{
    [SerializeField] private BuyableSelectorScriptable towerSelector;
    public int Cost = 50;

    public BuyableSelectorScriptable TowerSelector => towerSelector;
}
