using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : Death
{
    [SerializeField] private int moneyAddCount;
    [SerializeField] private int scoreAddCount;
    protected override void Die(GameObject targ)
    {
        if(moneyAddCount > 0) Money.PlayerMoney?.Add(moneyAddCount);
        if(scoreAddCount > 0) 
        {
            PlayerScore.Instance?.AddScore(scoreAddCount);
        }
        base.Die(targ);
    }
}
