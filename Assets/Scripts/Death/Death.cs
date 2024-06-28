using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] private EntityHealth health;
    [SerializeField] GameObject target;

    public event Action<GameObject> DieEvent;
    private void Start() {
        health.DamageRecieved += (damage) =>
        {
            if(health.Value > 0) return;
            Die(target);
        };
    }

    protected virtual void Die(GameObject targ)
    {
        DieEvent?.Invoke(gameObject);
        Destroy(targ);
    }
}
