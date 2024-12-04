using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EffectsContainer : MonoBehaviour
{
    List<IStatusEffect> effects = new List<IStatusEffect>();

    public void AddEffect(IStatusEffect effect)
    {
        var eff = effects.Find((e) => e.GetType() == effect.GetType());
        if(eff != null)
        {
            eff.AddStack(effect);
            return;
        }
        if(!effect.TryAddToEntity(this.gameObject)) return;

        effects.Add(effect);
        effect.EffectEnded += () => {
            effects.Remove(effect);
            effect.OnRemoveFromEntity(this.gameObject);
        };
    }

    public T GetEffect<T>() where T : IStatusEffect
    {
        return (T)effects.Find((d) => d.GetType() == typeof(T));
    }    
}   
