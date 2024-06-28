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
    }
}
