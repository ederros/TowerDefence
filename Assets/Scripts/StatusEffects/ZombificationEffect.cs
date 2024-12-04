using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombificationEffect : IStatusEffect
{
    private GameObject _parent;
    private LayerMask _targets;
    public ZombificationEffect(GameObject parent, LayerMask targets)
    {
        _parent = parent;
        _targets = targets;
    }
    public event Action EffectEnded;

    int stackCount;

    private Death _death;
    
    public void AddStack(IStatusEffect effect)
    {
        stackCount++;
        Debug.Log("Stack " + stackCount);
    }

    public bool TryAddToEntity(GameObject entity)
    {
        if(!entity.TryGetComponent(out Death death)) return false;
        _death = death;
        death.DieEvent += Zombification;
        stackCount = 1;
        return true;
    }

    public void OnRemoveFromEntity(GameObject entity)
    {
        _death.DieEvent -= Zombification;
    }

    public void RemoveStack()
    {
        stackCount--;
        if(stackCount <= 0)
            EffectEnded.Invoke();
    }

    private void Zombification(GameObject target)
    {
        GameObject zombie = UnityEngine.Object.Instantiate(target, target.transform.position, target.transform.rotation, _parent.transform);
        
        zombie.layer = _parent.layer;
        foreach (Transform child in zombie.transform)
        {
            child.gameObject.layer = _parent.layer;
        }

        
        if(zombie.TryGetComponent(out EntityHealth health))
        {
            health.AddValue(health.MaxValue);
        }
        if(zombie.TryGetComponent(out ContactAttack attack))
        {
            attack.SetTargets(_targets);
        }
        if(zombie.TryGetComponent(out Enemy enemy))
        {
            UnityEngine.Object.Destroy(enemy);
        }
        
        EffectEnded.Invoke();
    }
}
