using UnityEngine;
using UnityEngine.UI;

public class SliderVolumeSetter : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    
    private void Start() 
    {
        _slider.value = GamePreferences.Instance.MusicVolume;
        _slider.onValueChanged.AddListener(SetValue);
    }

    public void SetValue(float val)
    {
        GamePreferences.Instance.MusicVolume = val;
    }
}
