using UnityEngine;

public class NewTowerEnabler : MonoBehaviour
{
    [SerializeField] private int _wavesToNewTower;
    [SerializeField] private EndlessWave _waveSpawner;
    [SerializeField] private NewTowerManager _prefab;
    [SerializeField] private TowersPool _towerPool;
    [SerializeField] private Transform _playerSelectorsContent;

    [SerializeField] public Transform TowersContainer;

    public static NewTowerEnabler Instance;
    private int _currentWave = 0;

    public TowersPool TowerPool => _towerPool;

    private void Awake() 
    {
        Instance = this;
        _waveSpawner.CurrentWaveChanged += OnWaveChanged;
    }

    private void Start() 
    {
        Spawn();
    }

    private void OnWaveChanged(float difficulty)
    {
        _currentWave++;
        if(_currentWave % _wavesToNewTower == 0 && _towerPool.Towers.Count > 0)
        {
           Spawn();
        }
    }

    private void Spawn() => Instantiate(_prefab, transform).Init(_playerSelectorsContent, _towerPool);

}
