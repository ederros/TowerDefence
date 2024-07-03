using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScoreView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private PlayerScore _score;

    private void Start() 
    {
        if(_score != null)
            Init(_score);
    }

    public void Init(PlayerScore score)
    {
        _score = score;
        _score.scoreChanged += (int count) => 
        {
            _text.text = count.ToString();
        };
        _score.AddScore(0);
    }
}
