using System;
using UnityEngine;

public class EntityHealth : MonoBehaviour, IDamageReceiver
{
    [SerializeField] private float _value;
    [SerializeField] private float _maxValue;
    public event Action<float> ValueChanged;
    public event Action<float> MaxValueChanged;
    public event Action<float> DamageRecieved;

    public float Value 
    { 
        get => _value;
        set 
        {
            float oldValue = _value;
            _value = Mathf.Clamp(value, 0, _maxValue);
            ValueChanged?.Invoke(_value);
            if(_value < oldValue)
                DamageRecieved?.Invoke(oldValue - Value);
        }
    }

    public float MaxValue { 
        get => _maxValue; 
        set 
        {
            _maxValue = value;
            Value = this._value;
            MaxValueChanged?.Invoke(value);
        }
    }

    public void ReceiveDamage(float value)
    {
        Value -= value;
    }

    public void AddValue(float add)
    {
        if(add < 0)
        {
            Debug.LogWarning("Value must be equal or greater than 0");
            return;
        }
        Value += add;
    }

    public void SubValue(float sub)
    {
        if(sub < 0)
        {
            Debug.LogWarning("Value must be equal or greater than 0");
            return;
        }
        Value -= sub;
    }

    private void OnValidate() 
    {
        if(MaxValue > Value) return;
        _value = _maxValue;
    }
}
