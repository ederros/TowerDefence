using UnityEngine;

public class NewTowerEnabler : MonoBehaviour
{
    [SerializeField] private int _wavesToNewTower;
    [SerializeField] private EndlessWave _waveSpawner;
    [SerializeField] private NewTowerManager _view;
    [SerializeField] private NewTowerManager _prefab;
    
    public static NewTowerEnabler Instance;
    private int _currentWave = 0;

    private void Awake() 
    {
        _view.Init();
        Instance = this;
        _waveSpawner.CurrentWaveChanged += OnWaveChanged;
    }

    private void OnWaveChanged(float difficulty)
    {
        _currentWave++;
        if(_currentWave % _wavesToNewTower == 0 && _view.Towers.Count > 0)
        {
            _view.gameObject.SetActive(true);
            Instantiate(_prefab, transform);
            PauseManager.Pause();
        }
    }
}
