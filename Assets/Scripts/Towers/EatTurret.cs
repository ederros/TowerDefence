using UnityEngine;

public class EatTurret : MonoBehaviour
{
    [SerializeField] float damagePerTick = 1;
    [SerializeField] float tickTime = 1;
    [SerializeField] int goldPerKill = 5;
    private Enemy containedEnemy = null;
    private EntityHealth targetHealth;
    private float lastTick;

    private float containmentTime;

    private void EnemyFree(bool state, Enemy en)
    {
        en.Movement.enabled = state;
        en.DeathHandler.enabled = state;
        //en.GetComponent<Collider2D>().enabled = state;
        if(state) targetHealth.ValueChanged -= OnEnemyHPChanged;
        targetHealth = state ? null : en.GetComponent<EntityHealth>();
        if(!state) targetHealth.ValueChanged += OnEnemyHPChanged;
        en.GetComponent<Attack>().enabled = state;
        en.transform.position = transform.position;
        en.transform.rotation = Quaternion.identity;
        en.GetComponent<Rigidbody2D>().bodyType = state? RigidbodyType2D.Dynamic : RigidbodyType2D.Static;
        foreach (Collider2D item in en.GetComponentsInChildren<Collider2D>())
        {
            item.enabled = state;
        }
        
    }

    private void OnEnemyHPChanged(float hp)
    {
        if(hp > 0) return;
        Money.PlayerMoney.Add(goldPerKill);
    }

    private void GainMoney()
    {
        Money.PlayerMoney.Add(1);
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(containedEnemy != null) return;
        if(other.attachedRigidbody == null) return;
        if(!other.attachedRigidbody.TryGetComponent(out Enemy en)) return;
        if((en.Tags & Enemy.EnemyTags.Boss) != 0) return;
        EnemyFree(false, en);
        
        containedEnemy = en;
        lastTick = Time.time;
    }

    private void Update() 
    {
        if(containedEnemy == null) return;
        if(lastTick + tickTime > Time.time) return;
        containedEnemy.transform.rotation = Quaternion.identity;
        lastTick = Time.time;
        targetHealth.ReceiveDamage(damagePerTick);
    }

    private void OnDestroy() 
    {
        if(containedEnemy == null) return;
        EnemyFree(true, containedEnemy);
    }
}
