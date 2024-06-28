using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyView : MonoBehaviour
{
    [SerializeField] TMP_Text text; 
    string startText;
    private void Start() 
    {
        startText =  text.text;
        Money.PlayerMoney.CountChanged += (int c) => 
        {
            //Debug.Log("coins added");
            text.text = ""+c;
        };
        Money.PlayerMoney.Add(0);
    }
}
