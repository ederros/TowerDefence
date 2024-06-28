using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TowerBuySelector : MonoBehaviour
{
    [SerializeField] BuyableSelectorScriptable buyableSelector;
    [SerializeField] TMP_Text text;
    [SerializeField] Transform viewTarget;
    [SerializeField] float tapDuration = 0.1f;
    [SerializeField] Cooldown cooldown;

    bool isInited = false;
    public void SetTower(BuyableSelectorScriptable buyableSelector, float scale = 150)
    {
        this.buyableSelector = buyableSelector;
        text.text = buyableSelector.Cost.ToString();
        Transform view = buyableSelector.Prefab.transform.Find("View");
        if(view != null)
        {
            Transform t = Instantiate(view, viewTarget);
            GameObject go = t.gameObject;
            SpriteToImage(t);
            go.GetComponent<RectTransform>().localScale *= scale;
        }
        isInited = true;
    }
    
    private void Start() 
    {
        if(!isInited)
            SetTower(buyableSelector);

        cooldown.SetTime(buyableSelector.cooldown);
    }
    public static void SpriteToImage(Transform t)
    {
        
        RectTransform rt = t.AddComponent<RectTransform>();
        
        if(rt.TryGetComponent(out SpriteRenderer sr))
        {
            Image img = rt.AddComponent<Image>();
            img.sprite = sr.sprite;
            img.color = sr.color;
            //rt.localScale *=100;
            Destroy(sr);
        }
           
        foreach(Transform tr in rt)
        {
            SpriteToImage(tr);
        }
    }
    
    public void Buy()
    {
        if(cooldown.IsCooldowned) return;
        if(!GridTowerField.gridTowerField.CheckTile(PlayerCircleMovement.PlayerMovement.transform.position)) return;
        if(GridTowerField.gridTowerField.CheckForTower(PlayerCircleMovement.PlayerMovement.transform.position)) return;
        if(!Money.PlayerMoney.TrySub(buyableSelector.Cost)) return;
        
        GameObject tower = Instantiate(buyableSelector.Prefab, PlayerCircleMovement.PlayerMovement.transform.position, Quaternion.identity);
        GridTowerField.gridTowerField.SetTower(PlayerCircleMovement.PlayerMovement.transform.position, tower);
        //PlayerCircleMovement.PlayerMovement.RandomDash();
        cooldown.StartCooldown();
    }

    // public void OnPointerDown(PointerEventData eventData)
    // {
    //     lastTap = Time.time;
    //     dragFrames = 0;
    // }

    // public void OnPointerUp(PointerEventData eventData)
    // {
    //     Debug.Log(dragFrames);
    //     if(lastTap + tapDuration < Time.time || dragFrames > 2) return;
    //     if(Money.PlayerMoney.TrySub(buyableSelector.Cost))
    //         Buy();
    // }

    // public void OnPointerMove(PointerEventData eventData)
    // {
    //     dragFrames++;
    //     Debug.Log("Dragged");
    // }
}
