using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _parent;

    public void Spawn() => Instantiate(_prefab, _parent);
    
}
