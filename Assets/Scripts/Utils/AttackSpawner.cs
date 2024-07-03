using UnityEngine;

public class AttackSpawner : MonoBehaviour
{
    [SerializeField] private Attack _attack;
    [SerializeField] private GameObject _prefab;
    void Start()
    {
        _attack.Attacked += () => Instantiate(_prefab, transform.position, transform.rotation);
    }
}
