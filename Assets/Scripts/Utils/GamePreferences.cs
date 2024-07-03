using UnityEngine;
public class GamePreferences
{

    private static GamePreferences _instance = null;
    public static GamePreferences Instance
    {
        get{
            if(_instance == null) _instance = new GamePreferences();
            return _instance;
        }
    }

    public event System.Action PreferencesChanged;
    public float MusicVolume 
    { 
        get => _musicVolume; 
        set{
            _musicVolume = value; 
            PlayerPrefs.SetFloat(nameof(_musicVolume), _musicVolume);
            PreferencesChanged?.Invoke();
        }
    }

    private float _musicVolume = 1;

    private GamePreferences()
    {
        _musicVolume = PlayerPrefs.GetFloat(nameof(_musicVolume), _musicVolume);
    }

}
