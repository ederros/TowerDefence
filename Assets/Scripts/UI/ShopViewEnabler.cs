using UnityEngine;

public class ShopViewEnabler : MonoBehaviour
{
    [SerializeField] private ShopSelectorsManager _shopSelectorsManager;

    public void Enable()
    {
        Instantiate(_shopSelectorsManager, transform).Init();
        PauseManager.Pause();
    }
}
