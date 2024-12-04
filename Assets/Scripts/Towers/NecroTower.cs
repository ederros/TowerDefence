using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

[RequireComponent(typeof(Finder))]
public class NecroTower : MonoBehaviour
{
    [SerializeField] private Finder _finder;
    private void Start() 
    {
        _finder.Entered += (e) => 
        {
            Debug.Log("1");
            if(!e.TryGetComponent(out EffectsContainer container)) return;
            Debug.Log("2");
            container.AddEffect(new ZombificationEffect(this.gameObject, _finder.Layers));
        };

        _finder.Outted += (e) => 
        {
            if(!e.TryGetComponent(out EffectsContainer container)) return;
            container.GetEffect<ZombificationEffect>()?.RemoveStack();
        };
    }

}
