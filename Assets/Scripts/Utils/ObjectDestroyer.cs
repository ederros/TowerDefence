using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    [SerializeField] protected GameObject _object;

    public virtual void Destroy()
    {
        Destroy(_object);
    }
}
