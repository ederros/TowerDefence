using System.Collections;
using UnityEngine;

public class BlurAnimation : MonoBehaviour
{
    [SerializeField] private Material _mat;
    [SerializeField] private float _targetValue = 8;
    [SerializeField] private float _time = 1;

    private void Start() 
    {
        PauseManager.Pause();
        StartCoroutine(Blur());
    }

    private IEnumerator Blur()
    {
        float startTime = Time.unscaledTime;

        while(startTime + _time > Time.unscaledTime)
        {
            yield return null;
            _mat.SetFloat("_Size", Mathf.Lerp(0, _targetValue, (Time.unscaledTime - startTime) / _time));
        }
    }
}
