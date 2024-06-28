using UnityEngine;
public interface IDamageReceiver
{
    public event System.Action<float> DamageRecieved;
    public void ReceiveDamage(float value);
}
