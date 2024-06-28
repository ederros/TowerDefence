using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopBuySelector : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    [SerializeField] BuyableSelectorScriptable buyableSelector;
    [SerializeField] Transform viewTarget;

    private int price;

    private Money money;
    public event Action BuyEvent;


    public ShopBuySelector SetMoney(Money money)
    {
        this.money = money;
        return this;
    }

    public ShopBuySelector SetPrice(int price)
    {
        this.price = price;
        text.text = price.ToString();
        return this;
    }
    public ShopBuySelector SetSelector(BuyableSelectorScriptable selector)
    {
        Debug.Log(selector);
        buyableSelector = selector;
        return this;
    }

    private void Start() 
    {
        Transform view = buyableSelector.Prefab.transform.Find("View");
        if(view != null)
        {
            Transform t = Instantiate(view, viewTarget);
            GameObject go = t.gameObject;
            TowerBuySelector.SpriteToImage(t);
            go.GetComponent<RectTransform>().localScale *= 150;
        }
    }

    public void Buy()
    {
        if(!money.TrySub(price)) return;
        NewTowerManager.Instance.AddToPool(buyableSelector);
        BuyEvent?.Invoke();
        Destroy(this.gameObject);
    }
}
