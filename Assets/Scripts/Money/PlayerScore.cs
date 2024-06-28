using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour, ISaveLoadable
{
    private static PlayerScore instance;
    private class DataToSave
    {
        public int scoreCount;
    }
    private Money score = new Money();

    public static PlayerScore Instance => instance;

    public Money Score => score;

    public event Action<int> scoreChanged;

    private void Awake() 
    {
        instance = this;
        score.CountChanged += (int c) => scoreChanged?.Invoke(c);
    }
    
    public void AddScore(int count)
    {
        score.Add(count);
    }
    public Type GetSavedDataType() => typeof(DataToSave);

    public void Load(object data)
    {
        score.Add(((DataToSave)data).scoreCount);
    }

    public void Save(out object data)
    {
        DataToSave dataToSave = new DataToSave
        {
            scoreCount = score.Count
        };
        data = dataToSave;
    }
}
