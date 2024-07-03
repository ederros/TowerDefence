using UnityEngine;

public class ShopViewEnabler : MonoBehaviour
{
    [SerializeField] private ShopContent _objectPrefab;
    [SerializeField] private ShopItemsManager _items;
    [SerializeField] private PlayerScore _playerScore;

    public void Enable()
    {
        Instantiate(_objectPrefab, transform).Init(_items, _playerScore);
        PauseManager.Pause();
    }
}
