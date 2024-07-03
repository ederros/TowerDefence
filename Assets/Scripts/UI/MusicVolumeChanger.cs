using UnityEngine;

public class MusicVolumeChanger : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    // Start is called before the first frame update
    void Start()
    {
        GamePreferences.Instance.PreferencesChanged += SetVolume;
        _audio.volume = GamePreferences.Instance.MusicVolume;
    }

    private void OnDestroy() 
    {
        GamePreferences.Instance.PreferencesChanged -= SetVolume;
    }

    private void SetVolume()
    {
        _audio.volume = GamePreferences.Instance.MusicVolume;
    }
}
