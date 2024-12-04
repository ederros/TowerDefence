using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finder : MonoBehaviour
{
    private List<GameObject> objects = new List<GameObject>();
    public IReadOnlyList<GameObject> Objects => objects;
    public event Action<GameObject> Entered;
    public event Action<GameObject> Outted;

    public LayerMask Layers;
    public void CheckAndClean()
    {
        objects.RemoveAll((e) => e == null);
    }

    private void Remove(GameObject gameObject)
    {
        objects.Remove(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if((other.attachedRigidbody.gameObject.layer & (1<<Layers.value)) == 0) return;
        if(other.attachedRigidbody.TryGetComponent(out Death death))
        {
            death.DieEvent += Remove;
        }
        objects.Add(other.attachedRigidbody.gameObject);
        Entered?.Invoke(other.attachedRigidbody.gameObject);
    }

    private void OnTriggerExit2D(Collider2D other) {
        if((other.attachedRigidbody.gameObject.layer & (1<<Layers.value)) == 0) return;
        if(other.attachedRigidbody.TryGetComponent(out Death death))
        {
            death.DieEvent -= Remove;
        }
        Outted?.Invoke(other.attachedRigidbody.gameObject);
        objects?.Remove(other.attachedRigidbody.gameObject);
    }
}
