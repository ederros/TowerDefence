using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStatusEffect
{
    public event System.Action EffectEnded;
    public bool TryAddToEntity(GameObject entity);
    public void OnRemoveFromEntity(GameObject entity);
    public void AddStack(IStatusEffect stack);
    public void RemoveStack();
}
