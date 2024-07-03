using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthFadeout : MonoBehaviour
{
    [SerializeField] private Gradient gradient;
    [SerializeField] private EntityHealth health;
    [SerializeField] private SpriteRenderer rend;
    [SerializeField] bool setOnStart = true;
    void Start()
    {
        if(setOnStart) rend.color = gradient.Evaluate(0);
        health.ValueChanged += (float t) => 
        {
            t /= health.MaxValue;
            if(rend == null) return;
            rend.color = gradient.Evaluate(1 - t);
        };
    }

    private void OnValidate() 
    {
        if(!setOnStart) return;
        if(rend == null) return;
        rend.color = gradient.Evaluate(0);
    }
}
