using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack : MonoBehaviour
{
    [SerializeField] protected float Damage = 1;
    [SerializeField] protected float attackInterval = 1;
    public event System.Action Attacked;
    public virtual bool Check() => true;
    protected float lastAttack = 0;
    public abstract void Punch();
    private const float REPEAT_RATE = 0.5f;

    void Update()
    {
        if(Check())
        if(lastAttack + attackInterval < Time.time)
        {
            Punch();
            Attacked?.Invoke();
            lastAttack = Time.time;
        }
    }
}
