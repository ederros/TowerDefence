using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleLifetimeDestroyer : ObjectDestroyer
{
    [SerializeField] private ParticleSystem _particleSystem;
    private void Start() {
        Destroy();
    }
    public override void Destroy()
    {
        Debug.Log(_particleSystem.main.startLifetime.constantMax);
        Destroy(_object, _particleSystem.main.startLifetime.constantMax);
    }
}
