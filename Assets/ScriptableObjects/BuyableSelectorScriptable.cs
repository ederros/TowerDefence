using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuyableSelectorScriptable", menuName = "BuyableSelectorScriptable", order = 0)]
public class BuyableSelectorScriptable : ScriptableObject 
{
    [SerializeField] int cost;
    [SerializeField] GameObject prefab;
    [SerializeField] float _cooldown = 5;
    [SerializeField] string description;

    public int Cost => cost;
    public GameObject Prefab => prefab;
    public float cooldown {
        get{return _cooldown;}
        set{_cooldown = value;}
    }

    public string Description => description;
}

