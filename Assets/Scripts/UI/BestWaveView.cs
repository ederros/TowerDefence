using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


[System.Serializable]
public class BestWaveView : MonoBehaviour, ISaveLoadable
{
    private class DataToSave
    {
        public int bestWave = 0;

        public DataToSave(int bestWave)
        {
            this.bestWave = bestWave;
        }
    }   

    [SerializeField] EndlessWave endless;
    [SerializeField] TMP_Text text;
    
    private int bestWave = 0;
    private int curWave = 0;
    private void Start() 
    {
        endless.CurrentWaveChanged += (float f) => {
            curWave++;
            if(curWave > bestWave) {
                bestWave = curWave;
            }
            //SaveLoadSystem.instance.Save();
            text.text = "Best " + bestWave;
        };
    }

    public void Load(object data)
    {
        bestWave = ((DataToSave)data).bestWave;
    }

    public void Save(out object data)
    {
        data = new DataToSave(bestWave);
    }

    public Type GetSavedDataType() => typeof(DataToSave);
}
