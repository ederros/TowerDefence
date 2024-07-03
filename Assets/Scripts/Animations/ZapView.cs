using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZapView : MonoBehaviour
{
    [SerializeField] private ZapAttack _attack;
    [SerializeField] private LineRenderer _zapPrefab;

    private void Awake() 
    {
        _attack.Zapped += (Vector3[] vectors) => 
        {
            Debug.Log(vectors.Length);
            for(int i = 0; i < vectors.Length; i++)
            {
                Debug.Log(vectors[i]);
            }
            LineRenderer line = Instantiate(_zapPrefab);
            line.positionCount = vectors.Length;
            line.SetPositions(vectors);
        };

    }

    
}
