using System.Collections;
using UnityEngine;

public class FreezeEffect : MonoBehaviour
{
    [SerializeField] private AttackEnemy _attack;
    [SerializeField] private float _speedMultuplier = 0.8f;
    [SerializeField] private float _time = 5f;
    void Start()
    {
        _attack.EnemyAttacked += Freeze;
    }

    public void Freeze(Enemy enemy)
    {
        enemy.Movement.Speed = enemy.Movement.Speed * _speedMultuplier;
        enemy.StartCoroutine(FreezeWaiter(enemy));
        
    }

    public void UnFreeze(Enemy enemy)
    {
        enemy.Movement.Speed = enemy.Movement.Speed / _speedMultuplier;
    }

    private IEnumerator FreezeWaiter(Enemy enemy)
    {
        yield return new WaitForSeconds(_time);
        UnFreeze(enemy);
    }
}
