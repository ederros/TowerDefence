using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField] EntityHealth hp;
    [SerializeField] TMP_Text text;
    void Start()
    {
        hp.ValueChanged += (h) => 
        {
            text.text = (int)(hp.Value / hp.MaxValue * 100) + "%";
        };
    }

    
}
