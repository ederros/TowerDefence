using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private int startMoney;
    void Awake()
    {
        Money.InitPlayerMoney();
        Money.PlayerMoney.Add(startMoney);
        #if UNITY_EDITOR
        Money.PlayerMoney.Add(10000);
        #endif
    }
}
