using System;
using TMPro;
using UnityEngine;

public class NewTowerSelector : MonoBehaviour
{

    public BuyableSelectorScriptable tower;
    [SerializeField] private Transform viewTarget;
    [SerializeField] private Transform content;
    [SerializeField] private TowerBuySelector selectorPrefab;
    [SerializeField] private float towerViewScale = 300;
    [SerializeField] private TMP_Text text;
    private Action action;
    public Transform GetViewTarget() => viewTarget;
    public void Init(BuyableSelectorScriptable tower, Action action)
    {
        gameObject.SetActive(true);
        this.tower = tower;
        this.action = action;
        if(tower == null){
            gameObject.SetActive(false);
            return;
        } 
        Transform view = tower.Prefab.transform.Find("View");
        
        if(view != null)
        {
            Transform t = Instantiate(view, viewTarget);
            GameObject go = t.gameObject;
            TowerBuySelector.SpriteToImage(t);
            go.GetComponent<RectTransform>().localScale *= towerViewScale;
        }

        if(text != null)
            text.text = tower.Description;
        
    }

    public void Clicked()
    {
        action?.Invoke();
        Instantiate(selectorPrefab, content).SetTower(tower);
    }
}
