using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Money
{
    private static Money playerMoney;


    public static Money PlayerMoney {
        get 
        {
            if(playerMoney == null) playerMoney = new Money();
            return playerMoney;
        }
    }

    public event Action<int> CountChanged;
    private int count = 0;
    public int Count => count;
    
    public static void InitPlayerMoney()
    {
        playerMoney = new Money();
    }

    public void Add(int count)
    {
        if(count < 0) return;
        this.count += count;
        CountChanged?.Invoke(this.count);
    }

    public bool TrySub(int count)
    {
        if(count <= 0) return false;
        if(this.count < count) return false;
        this.count -= count;
        CountChanged?.Invoke(this.count);
        return true;
    }
}
