using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;



public class WaveView : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    [SerializeField] EndlessWave wavesSpawner;
    int wave = 0;
    void Start()
    {
        wavesSpawner.CurrentWaveChanged += (float difficulty) => 
        {
            wave++;
            text.text = "Wave " + (wave);

        };
    }
}
