using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScoreView : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private PlayerScore score;

    private void Start() 
    {
        score.scoreChanged += (int count) => 
        {
            text.text = count.ToString();
        };
        score.AddScore(0);
    }
}
